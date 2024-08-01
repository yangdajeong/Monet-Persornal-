using System.Collections.Generic;
using UnityEngine;

namespace YDJ
{
    public class CSV_Reader : MonoBehaviour
    {
        private Dictionary<string, Dictionary<string, object>> pointData;

        [SerializeField] string pointDataPath;
        [SerializeField] List<float> xpoint; //포인트 위치
        [SerializeField] List<float> ypoint; //포인트 위치
        [SerializeField] List<int> next_id; //다음 아이디
        [SerializeField] PointManager pointBin;

        public List<float> Xpoint { get { return xpoint; } }
        public List<float> Ypoint { get { return ypoint; } }
        public List<int> NextId { get { return next_id; } }

        private void Awake()
        {
            pointData = CSVReader.ReadAndReturnDic(pointDataPath);

            foreach (var item in pointData.Values)
            {
                if (item["next_id"] is int id) //다운캐스팅
                {
                    if (pointBin.Level == id) //레벨과 CSV 값이 일치 하는지 확인
                    {
                        next_id.Add(id);

                        if (item["x"] is int xint)            //float xx = (float)item["X_Pos"]; //강제 형변환으로 위험할 수 있음
                        {
                            xpoint.Add((float)xint);
                        }
                        else if (item["x"] is float x) //다운캐스팅
                        {
                            xpoint.Add(x);
                        }

                        if (item["y"] is int yint)
                        {
                            ypoint.Add((float)yint);
                        }
                        else if (item["y"] is float y) //다운캐스팅
                        {
                            ypoint.Add(y);
                        }
                    }
                }
            }



            //pointData = CSVReader.Read(pointDataPath);

            //for (int i = 0; i < pointData.Count; i++)
            //{
            //    if (pointData[i] is int id) //다운캐스팅
            //    {
            //        if (pointBin.Level == id) //레벨과 CSV 값이 일치 하는지 확인
            //            next_id.Add(id);
            //    }

            //    //float xx = (float)item["X_Pos"]; //강제 형변환으로 위험할 수 있음
            //    if (item["x"] is int xint)
            //    {
            //        xpoint.Add((float)xint);
            //    }
            //    else if (item["x"] is float x) //다운캐스팅
            //    {
            //        xpoint.Add(x);
            //    }

            //    if (item["y"] is int yint)
            //    {
            //        ypoint.Add((float)yint);
            //    }
            //    else if (item["y"] is float y) //다운캐스팅
            //    {
            //        ypoint.Add(y);
            //    }
            //}

        }
    }
}
