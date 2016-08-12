using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using ModelBindingContext = System.Web.Mvc.ModelBindingContext;


namespace SportsStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : System.Web.Mvc.IModelBinder
    {

        private const string SessionKey = "Cart";



        /// <summary>Binds the model to a value by using the specified controller context and binding context.</summary>
        /// <returns>The bound value.</returns>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="bindingContext">The binding context.</param>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
                cart = (Cart) controllerContext.HttpContext.Session[SessionKey];
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[SessionKey] = cart;
            }

            return cart;
        }

    }
}