﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class ImageSlider
    {

        sliderDataContext objImage = new sliderDataContext();

        public IEnumerable<sliderimage> getImages()

        {
            var allImages = objImage.sliderimages.Select(x => x);
            return allImages;
        }

        public bool commitInsert(sliderimage NewImage)
        {
            objImage.sliderimages.InsertOnSubmit(NewImage);
            objImage.SubmitChanges();
            return true;
        }

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

        public sliderimage getImageById(int _id)
        {
            var oneImage = objImage.sliderimages.SingleOrDefault(x => x.Id == _id);
            return oneImage;
        }
    }
}