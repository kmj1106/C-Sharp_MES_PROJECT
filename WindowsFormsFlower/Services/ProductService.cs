using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFlower
{
    class ProductService
    {
        public List<ProductVO> GetProductAllList()
        {
            ProductDAC db = new ProductDAC();
            List<ProductVO> list = db.GetProductAllList();
            db.Dispose();

            return list;
        }

        public bool InsertProduct(ProductVO prod)
        {
            ProductDAC db = new ProductDAC();
            bool result = db.InsertProduct(prod);
            db.Dispose();

            return result;
        }

        public bool DeleteProduct(string pID)
        {
            ProductDAC db = new ProductDAC();
            bool result = db.DeleteProduct(pID);
            db.Dispose();

            return result;
        }

        public bool UpdateProduct(ProductVO prod)
        {
            ProductDAC db = new ProductDAC();
            bool result = db.UpdateProduct(prod);
            db.Dispose();

            return result;
        }

        public List<ProductVO> GetProductSearchList(
                    string prodID, string prodType)
        {
            ProductDAC db = new ProductDAC();
            List<ProductVO> list = db.GetProductSearchList(prodID, prodType);
            db.Dispose();

            return list;
        }
        
        public List<ProductVO> GetProductBOMAllList()
        {
            ProductDAC db = new ProductDAC();
            List<ProductVO> list = db.GetProductBOMAllList();
            db.Dispose();

            return list;
        }
        
        public List<ProductVO> GetProductBOMSearchList(string prodName)
        {
            ProductDAC db = new ProductDAC();
            List<ProductVO> list = db.GetProductBOMSearchList(prodName);
            db.Dispose();

            return list;
        }

        public List<BOMVO> GetBOMAllListFW(string prodID)
        {
            ProductDAC db = new ProductDAC();
            List<BOMVO> list = db.GetBOMAllListFW(prodID);
            db.Dispose();

            return list;
        }
        public List<BOMVO> GetBOMAllListRV(string matID)
        {
            ProductDAC db = new ProductDAC();
            List<BOMVO> list = db.GetBOMAllListRV(matID);
            db.Dispose();

            return list;
        }
    }
}
