using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class ImageSlider
    {
        sliderDataContext objImage = new sliderDataContext();
        //get all images and deatils from database
        public IEnumerable<sliderimage> getImages()

        {
            var allImages = objImage.sliderimages.Select(x => x);
            return allImages;
        }

        //insert
        public bool commitInsert(sliderimage NewImage)
        {
            using (objImage)
            {
                objImage.sliderimages.InsertOnSubmit(NewImage);
                objImage.SubmitChanges();
                return true;
            }
        }

        //delete
        public bool commitDelete(int _id)
        {
            using(objImage)
            {
                var objDelImage = objImage.sliderimages.SingleOrDefault(x => x.Id == _id);
                objImage.sliderimages.DeleteOnSubmit(objDelImage);
                objImage.SubmitChanges();
                return true;
            }
        }

        //get Image slider details by ID
        public sliderimage getImageById(int _id)
        {
            var oneImage = objImage.sliderimages.SingleOrDefault(x => x.Id == _id);
            return oneImage;
        }

        //update
        public bool commitUpdate( int _id, string _imagePath, string _title, string _desciption, string _link)
        {
            using(objImage)
            {
                var objUpImage = objImage.sliderimages.Single(x => x.Id == _id);
                //setting table column to new value being passed
                objUpImage.ImagePath = _imagePath;
                objUpImage.Title = _title;
                objUpImage.Description = _desciption;
                objUpImage.Link = _link;
                //commit update against database
                objImage.SubmitChanges();
                return true;
            }
        }
    }
}