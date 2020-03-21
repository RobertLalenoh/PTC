using System;
using System.Collections.Generic;
using System.Text;

namespace PTCData
{
    public class TrainingProductManager
    {
        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string,string>> ValidationErrors { get; set; }

        public List<TrainingProduct> Get(TrainingProduct trainingProduct)
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();
            ret = CreateMockData();

            if (!string.IsNullOrEmpty(trainingProduct.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(trainingProduct.ProductName.ToLower()));
            }

            return ret;
        }
        private List<TrainingProduct> CreateMockData()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "Robert Lalenoh",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://nul.nl",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "Dessi Siahaan",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://nul.nl",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "Mike Tyson",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://nul.nl",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "Bob Marley",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://nul.nl",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "John Legend",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://nul.nl",
                Price = Convert.ToDecimal(29.00)
            });


            return ret;
        } 

        public bool Validate(TrainingProduct entity)
        {
            ValidationErrors.Clear();
            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                if(entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "Product Name must not be all lower case"));

                }
            }
            return (ValidationErrors.Count == 0);
        }

        public bool Insert (TrainingProduct trainingProduct)
        {
            bool ret = false;

            ret = Validate(trainingProduct);

            if (ret)
            {
                //TODO vcreate insertcode
            }

            return true;
        }
    }
}
