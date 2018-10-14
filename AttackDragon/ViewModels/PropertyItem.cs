using AttackDragon.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AttackDragon.ViewModels
{
    public class PropertyItem : ViewModelBase
    {
        private ImageSource _imageSource;
        private MethodInfo _methodInfo;
        private MemberItemType _memberItemType;

        public ImageSource ImageSource {
            get => _imageSource;
            set { _imageSource = value; OnPropertyChanged(); }
        }

        private string GenericSignatre => (MethodInfo.IsGenericMethod) ? $"<{string.Join(", ", MethodInfo.GetGenericArguments().Select(c => c.Name))}>" : "";

        private string MethodSignature => (MemberItemType == MemberItemType.Method) ? $"({string.Join(", ", MethodInfo.GetParameters().Select(c => c.ParameterType))})" : "";

        public string Name => $"{MethodInfo.Name}{GenericSignatre}{MethodSignature}";

        public string StandardName => Name.MethodStandardName();

        public MethodInfo MethodInfo {
            get => _methodInfo;
            set { _methodInfo = value; OnPropertyChanged(); }
        }

        public MemberItemType MemberItemType {
            get => _memberItemType;
            set { _memberItemType = value; OnPropertyChanged(); }
        }
    }

    public enum MemberItemType
    {
        Method, Event, Property
    }
}
