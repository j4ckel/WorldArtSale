using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoty
{
    public class ClassArt : ClassNotify
    {
        private int _artID;
        private string _picturePath;
        private string _pictureDescription;
        private string _pictureTitel;

        public ClassArt()
        {

        }

        
        [Key]
        public int artID
        {
            get { return _artID; }
            set
            {
                if (value != _artID)
                {
                    _artID = value;
                    Notify("artID");
                }
            }
        }

        public string pictureTitel
        {
            get { return _pictureTitel; }
            set
            {
                if (value != _pictureTitel)
                {
                    _pictureTitel = value;
                    Notify("pictureTitel");
                }
            }
        }


        public string pictureDescription
        {
            get { return _pictureDescription; }
            set
            {
                if (value != _pictureDescription)
                {
                    _pictureDescription = value;
                    Notify("pictureDescription");
                }
            }
        }


        public string picturePath
        {
            get { return _picturePath; }
            set
            {
                if (value != _picturePath)
                {
                    _picturePath = value;
                    Notify("picturePath");
                }
            }
        }

    }
}
