using Android.Content;
using Java.Util;
using SwagApp2.CustomControls;
using SwagApp2.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ButtonWithoutShadow), typeof(ButtonWithoutShadowRenderer))]
namespace SwagApp2.Droid.CustomRenderers
{
    public class ButtonWithoutShadowRenderer : ButtonRenderer
    {
        public ButtonWithoutShadowRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Elevation = 0;
            }

        }
    }
}