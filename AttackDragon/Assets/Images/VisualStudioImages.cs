using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AttackDragon.Assets.Images
{
    public static class VisualStudioImages
    {
        public static Lazy<ImageSource> Class => new Lazy<ImageSource>(GetImageByName());

        public static Lazy<ImageSource> Application => new Lazy<ImageSource>(GetImageByName());

        public static Lazy<ImageSource> Library => new Lazy<ImageSource>(GetImageByName());

        public static Lazy<ImageSource> Method => new Lazy<ImageSource>(GetImageByName());

        public static Lazy<ImageSource> Property => new Lazy<ImageSource>(GetImageByName());

        public static Lazy<ImageSource> Event => new Lazy<ImageSource>(GetImageByName());

        private static Func<ImageSource> GetImageByName([CallerMemberName]string memberName = "")
        => () => (ImageSource)App.Current.Resources[$"VisualStudio.{memberName}"];

    }
}
