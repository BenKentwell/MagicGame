using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource playerSource;
    [SerializeField] private AudioClip playerDamage;
    [SerializeField] private AudioClip playerKill;
    [SerializeField] private AudioClip playerSingle;
    [SerializeField] private AudioClip playerBeam;
    [SerializeField] private AudioClip playerScatter;

    [SerializeField] private AudioSource enemySource;
    [SerializeField] private AudioClip enemyDamage;
    [SerializeField] private AudioClip enemySound;
    [SerializeField] private AudioClip crystalDamage;

    [SerializeField] private AudioSource music;
    [SerializeField] private AudioClip backgrondmusic;
    [SerializeField] private AudioClip bossmusic;

    #region Enemy
    public void PlayDamageEnemy()
    {
        enemySource.clip = enemyDamage;
        enemySource.Play();
    }

    public void PlaySoundEnemy()
    {
        enemySource.clip = enemySound;
        enemySource.Play();
    }

    public void PlayDamageCrystal()
    {
        enemySource.clip = crystalDamage;
        enemySource.Play();
    }

    #endregion

    #region Player
    public void PlayDamagePlayer()
    {
        if (playerSource.clip == playerDamage && playerSource.isPlaying)
            return;
        playerSource.clip = playerDamage;
        playerSource.Play();
    }

    public void PlayKillPlayer()
    {
        playerSource.clip = playerKill;
        playerSource.Play();
    }

    public void PlayBeamPlayer()
    {
       
        playerSource.clip = playerBeam;
        playerSource.Play();
    }

    public void StopBeamPlayer()
    {
        if(playerSource.clip == playerBeam)
            playerSource.Stop();
    }


    public void PlayScatterPlayer()
    {
       
        playerSource.clip = playerScatter;
        playerSource.Play();
    }
    public void PlaySinglePlayer()
    {
        
        playerSource.clip = playerSingle;
        playerSource.Play();
    }
    #endregion


    #region Background
    public void PlayBackground()
    {
        music.clip = backgrondmusic;
        music.Play();
    }

    public void StopBackground()
    {
        music.Stop();
    }

    public void PlayBossMusic()
    {
        music.clip = bossmusic;
        music.Play();
    }

    #endregion



    private void Start()
   {
       PlayBackground();
   }
}
