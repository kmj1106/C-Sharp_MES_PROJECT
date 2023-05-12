﻿using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsFlower
{
    class BOMService
    {
        public List<BOMVO> GetBOMAllList()
        {
            BOMDAC db = new BOMDAC();
            List<BOMVO> list = db.GetBOMAllList();
            db.Dispose();

            return list;
        }

        public List<BOMVO> GetBOMSearchList(string BOMID)
        {
            BOMDAC db = new BOMDAC();
            List<BOMVO> list = db.GetBOMSearchList(BOMID);
            db.Dispose();

            return list;
        }

        public bool InsertBOM(string prodID, List<MaterialBOMVO> bom)
        {
            BOMDAC db = new BOMDAC();
            bool result = db.InsertBOM(prodID, bom);
            db.Dispose();

            return result;
        }
        //public bool DeleteBOMList(BOMVO bom)
        //{
        //    BOMDAC db = new BOMDAC();
        //    bool result = db.DeleteBOMList(bom);
        //    db.Dispose();

        //    return result;
        //}

        public List<MaterialBOMVO> GetBOMProd(string pid)
        {
            BOMDAC db = new BOMDAC();
            List<MaterialBOMVO> list = db.GetBOMProd(pid);
            db.Dispose();

            return list;
        }

        public List<MaterialBOMVO> GetBOMMat(string pid)
        {
            BOMDAC db = new BOMDAC();
            List<MaterialBOMVO> list = db.GetBOMMat(pid);
            db.Dispose();

            return list;
        }


    }
}
