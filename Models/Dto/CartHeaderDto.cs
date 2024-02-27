﻿namespace Mango.Services.OrderAPI.Models.Dto
{
    public class CartHeaderDto
    {

        public int CartHeaderId { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }
        public double Discount { get; set; }
        public double CartTotal { get; set; }

        // per messagebus Azure
       
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
