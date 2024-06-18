using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.InputModel
{
    public class UpdateDeliveryPersonInputModel
    {
        public long Id { get; set; }
        public string ImageLocation { get; private set; }

        public string base64image { get; set; }

        public string FileName { get; set; }

        public void updateImageLocation (string imageLocation)
        { 
            this.ImageLocation = imageLocation; 
        }

    }
}
