using System;
using System.Text;
using System.Collections.Generic;

namespace mmp
{
    public delegate void EventDelegate();

    public class Player
    {
        FMOD.System system;
        FMOD.Sound sound;
        FMOD.Channel channel;
        float volume;
        bool playing;

        public EventDelegate onPlay;

        public Player()
        {
            FMOD.Factory.System_Create(ref system);
            system.init(1, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
            volume = 1;
        }

        public List<KeyValuePair<FMOD.GUID, string>> GetDeviceList()
        {
            List<KeyValuePair<FMOD.GUID, string>> result = new List<KeyValuePair<FMOD.GUID, string>>();
            int numdrivers = 0;
            system.getNumDrivers(ref numdrivers);
            for (int i = 0; i < numdrivers; i++)
            {
                StringBuilder namebuilder = new StringBuilder(200);
                FMOD.GUID guid = new FMOD.GUID();
                system.getDriverInfo(i, namebuilder, namebuilder.Capacity, ref guid);
                result.Add(new KeyValuePair<FMOD.GUID, string>(guid, namebuilder.ToString()));
            }
            return result;
        }

        public void SetDevice(int index)
        {
            system.setDriver(index);
        }

        public int GetDevice()
        {
            int num = 0;
            system.getDriver(ref num);
            return num;
        }

        public bool Load(string path)
        {
            return system.createStream(path, FMOD.MODE.DEFAULT, ref sound) == FMOD.RESULT.OK;
        }

        public void Play()
        {
            if (sound != null)
            {
                system.playSound(FMOD.CHANNELINDEX.FREE, sound, false, ref channel);
                if (channel != null)
                {
                    channel.setVolume(volume);
                    playing = true;
                    onPlay();
                }
            }
        }

        public void Pause()
        {
            if (channel != null)
            {
                channel.setPaused(true);
                playing = false;
            }
        }

        public void Resume()
        {
            if (channel != null)
            {
                channel.setPaused(false);
                playing = true;
            }
        }

        public void Stop()
        {
            playing = false;
            if (channel != null)
            {
                channel.stop();
            }
        }

        public void Volume(float value)
        {
            if (channel != null)
                channel.setVolume(value);
            volume = value;
        }

        public bool IsPlaying()
        {
            if (channel != null)
            {
                bool playing = false;
                channel.isPlaying(ref playing);
                return playing;
            }
            return false;
        }

        public bool IsPaused()
        {
            if (channel != null)
            {
                bool paused = false;
                channel.getPaused(ref paused);
                return paused;
            }
            return false;
        }

        public float GetVolume()
        {
            return volume;
        }

        public bool Tick()
        {
            system.update();
            return playing && !IsPlaying();
        }

        public uint GetPosition()
        {
            if (channel != null)
            {
                uint lenms = 0;
                channel.getPosition(ref lenms, FMOD.TIMEUNIT.MS);
                return lenms;
            }
            return 0;
        }

        public uint GetLength()
        {
            if (sound != null)
            {
                uint lenms = 0;
                sound.getLength(ref lenms, FMOD.TIMEUNIT.MS);
                return lenms;
            }
            return 0;
        }

        public void Position(uint lenms)
        {
            if (channel != null)
            {
                channel.setPosition(lenms, FMOD.TIMEUNIT.MS);
            }
        }

        public List<string> GetExtensionsSupported()
        {
            List<string> exs = new List<string>();
            exs.Add("mp3");
            exs.Add("wav");
            exs.Add("wma");
            exs.Add("wave");
            exs.Add("flac");
            exs.Add("wma");
            exs.Add("wmv");
            exs.Add("ogg");
            exs.Add("mod");
            exs.Add("aiff");
            exs.Add("aif");
            exs.Add("aifc");
            exs.Add("asf");
            exs.Add("asx");
            exs.Add("rmi");
            exs.Add("mp2");
            exs.Add("oga");
            exs.Add("s3m");
            exs.Add("xm");
            exs.Add("it");
            return exs;
        }
    }
}
