using System;
using System.Collections.Generic;
using System.Text;

namespace LightFramework.Base
{
    public class BasePage : Base
    {
        public BasePage() : base() { }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
