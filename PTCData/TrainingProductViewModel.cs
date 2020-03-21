using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
   public class TrainingProductViewModel
    {

        public TrainingProductViewModel()
        {
            Init();
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
        }

        public TrainingProduct Entity { get; set; }
        public string EventCommand { get; set; }
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }
        public bool IsValid { get; set; }
        public int MyProperty { get; set; }
        public string Mode { get; set; }

        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }


        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearcAreaVisible { get; set; }

        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get(SearchEntity);
        }

        private void ListMode()
        {
            IsValid = true;
            IsListAreaVisible = true;
            IsSearcAreaVisible = true;
            IsDetailAreaVisible = false;
            Mode = "List";
        }

        private void AddMode()
        {
            IsListAreaVisible = false;
            IsSearcAreaVisible = false;
            IsDetailAreaVisible = true;
            Mode = "Add";
        }

        private void Add()
        {
            IsValid = true;
            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;
            AddMode();
        }

        private void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            if (Mode == "Add")
            {
                mgr.Insert(Entity);
            }

            ValidationErrors = mgr.ValidationErrors;
            if(ValidationErrors.Count > 0)
            {
                IsValid = false;
            }

            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
            }
         
        }
        private void Init()
        {

            ValidationErrors = new List<KeyValuePair<string, string>>();

            EventCommand = "List";

            ListMode();
        }

        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;
                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;
                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;
                case "cancel":
                    ListMode();
                    Get();
                    break;
                case "add":
                    Add();
                    break;
                default:
                    break;
            }
        }

    }
}
