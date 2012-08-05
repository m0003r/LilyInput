using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Midi;

namespace LilyInput
{
    public partial class SettingsWindow : Form
    {        
        private List<Pitch> notes;
        private Dictionary<Pitch, float> events;
        private PitchConsumer cons;
        private bool sustain = false;
        InputDevice d;

        public SettingsWindow()
        {
            InitializeComponent();
            LoadMidiDevices();
            cons = new PitchConsumer(0, true);
            notes = new List<Pitch>();
            events = new Dictionary<Pitch, float>();
        }

        private void LoadMidiDevices()
        {
            foreach (InputDevice d in InputDevice.InstalledDevices)
            {
                DeviceList.Items.Add(d.Name);
            }
            DeviceList.SelectedIndex = 0;

            UpdateDevice();
        }

        private void updateConsumer()
        {
            cons.keys = (int)KeySign.Value;
            cons.isMajor = major.Checked;
        }

        private void UpdateDevice()
        {
            if (d != null)
            {
                if (d.IsReceiving)
                    d.StopReceiving();
                if (d.IsOpen)
                    d.Close();
            }

            d = InputDevice.InstalledDevices[DeviceList.SelectedIndex];
            if (!d.IsOpen)
                d.Open();

            if (d.IsReceiving)
                d.StopReceiving();

            d.StartReceiving(null);

            if (d != null)
            {
                d.NoteOn += new InputDevice.NoteOnHandler(this.NoteOn);
                d.NoteOff += new InputDevice.NoteOffHandler(this.NoteOff);
                d.ControlChange += new InputDevice.ControlChangeHandler(this.ControlChange);
            }
        }

        private void DeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDevice();
        }

        public void NoteOn(NoteOnMessage msg)
        {
            lock (this)
            {
                events[msg.Pitch] = msg.Time;
            }
        }

        public void NoteOff(NoteOffMessage msg)
        {
            lock (this)
            {
                if (events.ContainsKey(msg.Pitch))
                {
                    if (msg.Time - events[msg.Pitch] > 0.05)
                    {
                        notes.Add(msg.Pitch);
                    }
                    events.Remove(msg.Pitch);

                    if ((events.Count == 0) && (notes.Count > 0))
                    {
                        SendKeys.SendWait(" " + cons.Convert(notes));
                        notes.Clear();
                    }
                }
            }
        }

        public void ControlChange(ControlChangeMessage msg)
        {
            if (msg.Control == Midi.Control.SustainPedal)
            {
                if ((msg.Value > 64) && !sustain)
                {
                    sustain = true;
                    SendKeys.SendWait("{(}");
                }
                if ((msg.Value < 64) && sustain)
                {
                    sustain = false;
                    SendKeys.SendWait("{)}");
                }
            }
            return;
        }

        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            d.StopReceiving();
            d.Close();
        }

        private void KeySign_ValueChanged(object sender, EventArgs e)
        {
            updateConsumer();
        }

        private void major_CheckedChanged(object sender, EventArgs e)
        {
            updateConsumer();
        }

        private void minor_CheckedChanged(object sender, EventArgs e)
        {
            updateConsumer();
        }
    }
}
