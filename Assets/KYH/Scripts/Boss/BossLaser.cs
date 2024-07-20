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
        // Ÿ�̸� �ʱ�ȭ
        timer = laserInterval;
        // LineRenderer �ʱ�ȭ
        laserLine.enabled = false;
        laserLine.startColor = new Color(1, 0, 0, 0); // ����
        laserLine.endColor = new Color(1, 0, 0, 0); // ����
    }

    void Update()
    {
        timer -= Time.deltaTime * SNL.data.timeScale;

        if (timer <= 0)
        {
            StartCoroutine(FireLaser());
            timer = laserInterval; // Ÿ�̸� ����
        }
    }

    IEnumerator FireLaser()
    {
        // ������ ��ġ ����
        laserLine.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -5f));
        laserLine.SetPosition(1, new Vector3(player.position.x, player.position.y, -5f));

        // ��� �ܰ�
        laserLine.enabled = true;
        laserLine.startColor = new Color(1, 0, 0, 0.5f); // ������
        laserLine.endColor = new Color(1, 0, 0, 0.5f); // ������
        yield return new WaitForSeconds(warningDuration);

        // ������ �߻� �ܰ�
        laserLine.startColor = new Color(1, 0, 0, 1f); // ���� ������
        laserLine.endColor = new Color(1, 0, 0, 1f); // ���� ������
        yield return new WaitForSeconds(laserDuration);

        // ������ ����� �ܰ�
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
