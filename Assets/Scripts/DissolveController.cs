using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public Material dissolveMaterial;
    public float duration = 2f;
    void Start()
    {
        dissolveMaterial = GetComponent<Renderer>().material;
        StartCoroutine(ChangeAmountOverTime());
    }

    IEnumerator ChangeAmountOverTime()
    {
        float elapsed = 0f;                        //��� �ð�
        float startValue = -1f;                    //���� ��
        float endValue = 1f;                       //�� ��

        while (elapsed < duration)                         //duration���� �ݺ�
        { 
            elapsed += Time.deltaTime;                     //�� ������ ��� �ð� �߰�  
            float t = Mathf.Clamp01(elapsed / duration);     //0~1 ���� ������ ��ȯ
            float value = Mathf.Lerp(startValue, endValue, t);           //���� �������� �� ��� (-1 -> 1)
            dissolveMaterial.SetFloat("_Amount", value);                   //��Ƽ������ Amount �Ӽ��� �� ����
            yield return null;                                              //���� �����ӱ��� ���
        }

        dissolveMaterial.SetFloat("_Amount", endValue);                      //���������� ������ Ȯ���ϰ� ����
    }
    void Update()
    {
        
    }
}
