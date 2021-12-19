using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLDataShow : MonoBehaviour
{
    //x�����������
    public int numX;//��ʵ���ݸ���
    // �����������ݵı���
    public List<float> dataList = new List<float>();
    //����ƫ����
    private float offsetX;
    // 
    public Material mat;
    IEnumerator Start()
    {
        yield return new WaitForFixedUpdate();
        //���Դ���
        InvokeRepeating("Test", 1, 1);
        //����ƫ��
        offsetX = GLGrid.instence.gridX / numX;
        Debug.Log(GLGrid.instence.gridX);
    }
    private void GetNewItem(float num)
    {
        if (dataList.Count > numX)
        {
            dataList.RemoveAt(0);
        }
        //�����ݴ���Ϊ��������
        dataList.Add(GLGrid.instence.GetPosYByWorths(num));
    }
    void Test()
    {
        float num = Random.Range(10, 20f);
        GetNewItem(num);
    }
    void OnPostRender()
    {
        GL.PushMatrix();
        mat.SetPass(0);
        GL.Begin(GL.LINES);
        for (int i = 0; i < dataList.Count - 1; i++)
        {
            //float z = GLGrid.instence.zero.z;
            Vector3 start = GLGrid.instence.zero + dataList[i] * GLGrid.instence.gridBg.up + GLGrid.instence.gridBg.right * offsetX * i;
            Vector3 end = GLGrid.instence.zero + dataList[i + 1] * GLGrid.instence.gridBg.up + GLGrid.instence.gridBg.right * offsetX * (i + 1);
            Debug.Log(GLGrid.instence.zero - start);
            //Vector3 end = Vector3.zero;
            //������  
            GL.Vertex(start);
            GL.Vertex(end);
        }
        GL.End();
        GL.PopMatrix();
    }
}
