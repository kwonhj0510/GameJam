using System.Collections;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public SaveAndLoad SNL;
    public LineRenderer laserLine;
    public Transform player;
    public float laserDuration = 0.5f;
    public float warningDuration = 1f;
    public float laserInterval = 10f;
    private float timer;

    void Start()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
        // 타이머 초기화
        timer = laserInterval;
        // LineRenderer 초기화
        laserLine.enabled = false;
        laserLine.startColor = new Color(1, 0, 0, 0); // 투명
        laserLine.endColor = new Color(1, 0, 0, 0); // 투명
    }

    void Update()
    {
        timer -= Time.deltaTime * SNL.data.timeScale;

        if (timer <= 0)
        {
            StartCoroutine(FireLaser());
            timer = laserInterval; // 타이머 리셋
        }
    }

    IEnumerator FireLaser()
    {
        // 레이저 위치 설정
        laserLine.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -5f));
        laserLine.SetPosition(1, new Vector3(player.position.x, player.position.y, -5f));

        // 경고 단계
        laserLine.enabled = true;
        laserLine.startColor = new Color(1, 0, 0, 0.5f); // 반투명
        laserLine.endColor = new Color(1, 0, 0, 0.5f); // 반투명
        yield return new WaitForSeconds(warningDuration);

        // 레이저 발사 단계
        laserLine.startColor = new Color(1, 0, 0, 1f); // 완전 불투명
        laserLine.endColor = new Color(1, 0, 0, 1f); // 완전 불투명
        yield return new WaitForSeconds(laserDuration);

        // 레이저 사라짐 단계
        float fadeDuration = 0.5f;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            laserLine.startColor = new Color(1, 0, 0, 1f - normalizedTime);
            laserLine.endColor = new Color(1, 0, 0, 1f - normalizedTime);
            yield return null;
        }

        laserLine.enabled = false;
    }
}
