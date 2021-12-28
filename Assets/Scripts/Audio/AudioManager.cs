﻿using System;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : Singleton<AudioManager>
    {
        public Sound[] sounds;

        [HideInInspector] public bool soundOn;

        // Start is called before the firs  t frame update
        protected override void Awake()
        {
            base.Awake();
            foreach(Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }

            soundOn = true;

            Play("Background");
        }
        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogError("Sound " + name + " is not found" );
                return;
            } 
            s.source.Play(); 
        }

        public void ChangeSounds(Sound audio1, Sound audio2)
        {
            audio1.source.Pause();
            audio2.source.Play();
        }

        public void Silence()
        {
            foreach(Sound s in sounds)
            {
                s.source.volume = 0;
            }
        }

        public void MakeMusic()
        {
            foreach(Sound s in sounds)
            {
                s.source.volume = s.volume;
            }
        }


        public void ChangeAudioVolume()
        {
            if(soundOn)
            {
                Silence();
                soundOn = false;
            }
                
            else
            {
                MakeMusic();
                soundOn = true;
            }
        }
    }
