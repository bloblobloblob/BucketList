//using Android.Content;
//using Android.Util;
//using Android.Widget;
//using BucketListApp;
//using BucketListApp.Droid;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(Goal), typeof(GoalRenderer))]
//namespace BucketListApp.Droid
//{
//    public class GoalRenderer : ViewRenderer<Goal, TextView>
//    {
//        public GoalRenderer(Context context) : base(context)
//        {
//        }
//        protected override void OnElementChanged(ElementChangedEventArgs<Goal> args)
//        {
//            base.OnElementChanged(args);
//            if (Control == null)
//            {
//                // создаем и настраиваем элемент
//                TextView textView = new TextView(Context);
//                textView.SetTextColor(Android.Graphics.Color.DarkGreen);
//                textView.Text = "Android";
//                textView.SetTextSize(ComplexUnitType.Dip, 28);

//                // устанавливаем элемент для класса из главного проекта
//                SetNativeControl(textView);
//            }
//        }
//    }
//}