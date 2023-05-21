namespace CoreWebApiAngularCapstoneProject.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        public string medicine_name { get; set; }

        public string medicine_img { get; set; }

        public string medicine_seller { get; set; }

        public double medicine_price { get; set; }

        public string medicine_details { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
       

    }
}
