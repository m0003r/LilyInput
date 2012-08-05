using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Midi;

namespace LilyInput
{
    class Grade
    {
        int Number;
        int Acc;

        private static String[] Naturals = { "c", "d", "e", "f", "g", "a", "h" };
        private static String[] Sharps = { "cis", "dis", "eis", "fis", "gis", "ais", "his" };
        private static String[] Flats = { "ces", "des", "es", "fes", "ges", "as", "b" };
        private static String[] DoubleSharps = { "cisis", "disis", "eisis", "fisis", "gisis", "aisis", "bisis" };
        private static String[] DoubleFlats = { "ceses", "deses", "eses", "feses", "geses", "ases", "beses" };

        public Grade(int number, int acc)
        {
            Number = number;
            Acc = acc;
        }

        public String resolveIn(int keys, bool isMajor)
        {
            int fAcc = Acc;
            int fs;
            int fNum;
            int numMod = Number % 7;

            fs = isMajor ? 6 : 3;

            fs = (fs - 2*numMod) % 7;

            if (fs <= 0)
                fs += 7;

            if (keys < 0)
                fs = 8 - fs;

            if (fs <= Math.Abs(keys))
                fAcc += keys / Math.Abs(keys);
            
            fNum = (numMod + keys*4 - (isMajor ? 0 : 2)) % 7;
            
            if (fNum < 0)
                fNum += 7;
                        
            switch (fAcc)
            {
                case -2: return DoubleFlats[fNum];
                case -1: return Flats[fNum];
                case 0: return Naturals[fNum];
                case 1: return Sharps[fNum];
                case 2: return DoubleSharps[fNum];
                default: return "";
            }
        }

        public static String operator -(Grade a, Grade g)
        {
            int o;

            o = a.Number - g.Number;
            o = (int)Math.Round((double)o / 7.0);

            if (o > 0)
                return new String('\'', o);
            if (o < 0)
                return new String(',', -o);

            return "";
        }
    }

    class PitchConsumer
    {
        private static Pitch lastPitch;
        public bool isMajor = true;
        public int keys = 0;

        public PitchConsumer(int keys, bool isMajor)
        {
            this.keys = keys;
            this.isMajor = isMajor;
        }

        public String Convert(List<Pitch> pitches)
        {
            Pitch localLast = lastPitch;
            String accum;

            if ((int)lastPitch == 0)
                lastPitch = pitches[0];

            pitches.Sort();
            if (pitches.Count == 1)
            {
                accum = toPitch(pitches[0], lastPitch);
                lastPitch = pitches[0];
            }
            else
            {
                lastPitch = pitches[0];
                accum = "<";
                foreach (Pitch p in pitches)
                {
                    if (accum.Length > 1)
                        accum += " ";
                    accum += toPitch(p, localLast);
                    localLast = p;
                }
                accum += ">";
            }
            return accum;
        }

        private String toPitch(Pitch p, Pitch last)
        {
            Grade g, glast;
            String note;

            g = toGrade(p);
            glast = toGrade(last);

            note = g.resolveIn(keys, isMajor);

            return note + (g - glast);
        }

        private static int[] majorScale = { 0, 1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6 };
        private static int[] majorAcc = { 0, -1, 0, -1, 0, 0, 1, 0, -1, 0, -1, 0 };
        private static int[] minorScale = { 0, 1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6 };
        private static int[] minorAcc = { 0, -1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1 };

        private Grade toGrade(Pitch p)
        {
            int keybase = (keys * 7) % 12 - (isMajor?0:3);
            int offset = ((int)p - keybase) % 12;
            int octave = (((int)p - keybase) / 12) * 7;
            int num, acc;

            if (offset < 0)
                offset += 12;

            if (isMajor)
            {
                num = majorScale[offset] + octave;
                acc = majorAcc[offset];
            }
            else
            {
                num = minorScale[offset] + octave;
                acc = minorAcc[offset];
            }

            return new Grade(num, acc);
        }

    }
}
