using System.Collections.Generic;
using System.IO;
using Config.StaticData;
using Newtonsoft.Json;

namespace SpringItUp
{
    public class Owner
    {
        private static Owner _instance;
        public static Owner Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Owner();
                return _instance;
            }
        }
        private static SourcePath _sourcePath;
        public static SourcePath SourcePath
        {
            get
            {
                if (_sourcePath == null)
                    _sourcePath = new SourcePath();
                return _sourcePath;
            }
        }

        private static List<OwnerModel> _allOwners;
        public List<OwnerModel> GetAll()
        {
            if (_allOwners == null)
                using (StreamReader r = new StreamReader(SourcePath.OwnerPath))
                {
                    string json = r.ReadToEnd();
                    _allOwners = JsonConvert.DeserializeObject<List<OwnerModel>>(json);
                }
            return _allOwners;
        }

        public OwnerModel GetById(int id)
        {
            if (_allOwners == null)
                GetAll();
            foreach (var owner in _allOwners)
            {
                if (owner.Id == id)
                    return owner;
            }
            return null;
        }

        public class OwnerModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }
    }
}