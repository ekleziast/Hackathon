using HtmlAgilityPack;
using OrenburgTourismFM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Spider
{
    public class Places
    {
        public static Place GetPlace(string url)
        {
            Place place = new Place();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Util.GetRequest(url));

            string placeType = doc.DocumentNode.SelectSingleNode("//a[@class='entity-info_category']").InnerText;
            
            string placeName = doc.DocumentNode.SelectSingleNode("//h1[@class='entity-info_title']").InnerText;
            
            string placePhoto = Meetings.Url + doc.DocumentNode.SelectSingleNode("//div[@class='entity-info_poster']/button/img").Attributes["src"].Value;
            placePhoto = placePhoto.Replace("_w90_h90", "");

            HtmlNodeCollection descriptionNodes = doc.DocumentNode.SelectNodes("//div[@class='content_view content_view__text']/p");
            StringBuilder descriptionBuilder = new StringBuilder();
            foreach (HtmlNode descriptionNode in descriptionNodes)
            {
                descriptionBuilder.Append(descriptionNode.InnerText);
            }

            place.PlaceType = new PlaceType { Name = placeType };
            place.Name = placeName;
            place.Photo = placePhoto;
            place.Description = descriptionBuilder.ToString();

            return place;
        }
    }
}
