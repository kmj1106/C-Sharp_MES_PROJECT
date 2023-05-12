using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFlower
{
    class MaterialService
    {
        public List<MaterialVO> GetMaterialsAllList()
        {
            MaterialDAC db = new MaterialDAC();
            List<MaterialVO> list = db.GetMaterialAllList();
            db.Dispose();

            return list;
        }

        public List<MaterialVO> GetMaterialSearchList(string MaterialID, string MaterialName)
        {
            MaterialDAC db = new MaterialDAC();
            List<MaterialVO> list = db.GetMaterialSearchList(MaterialID,MaterialName);
            db.Dispose();

            return list;
        }

        public bool InsertMaterials(MaterialVO material)
        {
            MaterialDAC db = new MaterialDAC();
            bool result = db.InsertMaterials(material);
            db.Dispose();

            return result;
        }
        public bool InsertBOMMaterials(MaterialVO material)
        {
            MaterialDAC db = new MaterialDAC();
            bool result = db.InsertBOMMaterials(material);
            db.Dispose();

            return result;
        }

        public bool DeleteMaterials(string matid)
        {
            MaterialDAC db = new MaterialDAC();
            bool result = db.DeleteMaterials(matid);
            db.Dispose();

            return result;
        }
        public bool UpdateMaterials(MaterialVO material)
        {
            MaterialDAC db = new MaterialDAC();
            bool result = db.UpdateMaterials(material);
            db.Dispose();

            return result;
        }

    }
}
