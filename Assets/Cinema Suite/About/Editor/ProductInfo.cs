
using UnityEditor;
using UnityEngine;
using UnityEditor.AnimatedValues;
using System;

namespace CinemaSuite
{
    public abstract class ProductInfo
    {
        public string name;
        protected string version;

        protected Texture2D keyImage;
        protected Texture2D fiveStars;

        protected Texture2D resourceImage1;
        protected Texture2D resourceImage2;
        protected Texture2D resourceImage3;
        protected Texture2D resourceImage4;

        protected string resourceImage1Link;
        protected string resourceImage2Link;
        protected string resourceImage3Link;
        protected string resourceImage4Link;

        protected string resourceImage1Label;
        protected string resourceImage2Label;
        protected string resourceImage3Label;
        protected string resourceImage4Label;

        protected string headerText;
        protected string header2Text;
        protected string bodyText;

        protected bool installed = false;
        protected string assetStorePage = "";

        public AnimBool ShowProductInfo;

        /// <summary>
        /// If used, be sure to call Initialize() after.
        /// </summary>
        public ProductInfo()
        {
            fiveStars = Resources.Load("FiveStars") as Texture2D;
        }

        public ProductInfo(UnityEngine.Events.UnityAction Repaint)
        {
            Initialize(Repaint);
        }

        public void Initialize(UnityEngine.Events.UnityAction Repaint)
        {
            ShowProductInfo = new AnimBool(true, Repaint);
        }

        internal virtual void OnGUI(Rect position)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.BeginVertical(GUILayout.Width(228));
            Rect keyImageRect = EditorGUILayout.GetControlRect(GUILayout.Height(128), GUILayout.Width(228));

            if (GUI.Button(keyImageRect, keyImage, EditorStyles.label))
            {
                Application.OpenURL(assetStorePage);
            }

            EditorGUIUtility.AddCursorRect(keyImageRect, MouseCursor.Link);

            GUI.skin.button.alignment = TextAnchor.MiddleCenter;
            GUI.skin.button.imagePosition = ImagePosition.ImageAbove;


            EditorGUILayout.BeginHorizontal();
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(42), GUILayout.Width(54));
            if (GUI.Button(rect, new GUIContent(resourceImage1Label, resourceImage1)))
            {
                Application.OpenURL(resourceImage1Link);
            }

            rect = EditorGUILayout.GetControlRect(GUILayout.Height(42), GUILayout.Width(54));
            if (GUI.Button(rect, new GUIContent(resourceImage2Label, resourceImage2)))
            {
                Application.OpenURL(resourceImage2Link);
            }

            rect = EditorGUILayout.GetControlRect(GUILayout.Height(42), GUILayout.Width(54));
            if (GUI.Button(rect, new GUIContent(resourceImage3Label, resourceImage3)))
            {
                Application.OpenURL(resourceImage3Link);
            }

            rect = EditorGUILayout.GetControlRect(GUILayout.Height(42), GUILayout.Width(56));
            if (GUI.Button(rect, new GUIContent(resourceImage4Label, resourceImage4)))
            {
                Application.OpenURL(resourceImage4Link);
            }
            EditorGUILayout.EndHorizontal();

            GUI.skin.label.alignment = TextAnchor.UpperLeft;

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical();

            GUI.skin.label.wordWrap = true;
            Rect heading1Rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));
            Rect heading2Rect = EditorGUILayout.GetControlRect(GUILayout.Height(18));
            Rect bodyRect = EditorGUILayout.GetControlRect(GUILayout.Height(128));

            GUI.Label(heading1Rect, headerText);
            GUI.Label(heading2Rect, header2Text);
            GUI.Label(bodyRect, new GUIContent(bodyText));

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
        }

    }

    public class CinemaDirectorBaseProductInfo : ProductInfo
    {
        public CinemaDirectorBaseProductInfo() : base()
        {
            name = "Cinema Director";
            keyImage = Resources.Load("DirectorKeyImage") as Texture2D;
            headerText = "<size=16>Cinema Director</size>";
            header2Text = "<size=14>Sequencer and Cutscene Editor.</size>";
            bodyText = "A sequencer and timeline editor, perfect for creating cutscenes and queueing up timed events and actions.";

            string suffix = EditorGUIUtility.isProSkin ? "_Pro" : "_Personal";

            resourceImage1 = Resources.Load("Cinema_Suite_Video" + suffix) as Texture2D;
            resourceImage2 = Resources.Load("Cinema_Suite_Store" + suffix) as Texture2D;
            resourceImage3 = Resources.Load("Cinema_Suite_Forums" + suffix) as Texture2D;
            resourceImage4 = Resources.Load("Cinema_Suite_Docs" + suffix) as Texture2D;

            resourceImage1Link = "https://youtu.be/ufxdul8GNdg";
            resourceImage2Link = "http://u3d.as/8vm";
            resourceImage3Link = "http://forum.unity3d.com/threads/cinema-director-released.258242/";
            resourceImage4Link = "http://www.cinema-suite.com/Documentation/CinemaDirector/CinemaDirectorDocumentation.pdf";

            resourceImage1Label = "Video";
            resourceImage2Label = "Store";
            resourceImage3Label = "Forum";
            resourceImage4Label = "Docs";

            assetStorePage = "http://u3d.as/8vm";
        }
    }

    public class CinemaMocapBaseProductInfo : ProductInfo
    {
        public CinemaMocapBaseProductInfo()
            : base()
        {
            name = "Cinema Mo Cap";
            keyImage = Resources.Load("MocapKeyImage") as Texture2D;
            headerText = "<size=16>Cinema Mo Cap</size>";
            header2Text = "<size=14>Markerless Motion Capture.</size>"; 
            bodyText = "Capture animations right inside of Unity using your Kinect or Kinect 2! Animations are Mecanim compatible and can be applied to any humanoid character.";
            string suffix = EditorGUIUtility.isProSkin ? "_Pro" : "_Personal";

            resourceImage1 = Resources.Load("Cinema_Suite_Video" + suffix) as Texture2D;
            resourceImage2 = Resources.Load("Cinema_Suite_Store" + suffix) as Texture2D;
            resourceImage3 = Resources.Load("Cinema_Suite_Forums" + suffix) as Texture2D;
            resourceImage4 = Resources.Load("Cinema_Suite_Docs" + suffix) as Texture2D;

            resourceImage1Link = "https://youtu.be/X_aEFKNDTYw";
            resourceImage2Link = "http://u3d.as/5PB";
            resourceImage3Link = "http://forum.unity3d.com/threads/cinema-mo-cap-released.217012/";
            resourceImage4Link = "http://www.cinema-suite.com/Documentation/CinemaMoCap/Current/CinemaMoCapDocumentation.pdf";

            resourceImage1Label = "Video";
            resourceImage2Label = "Store";
            resourceImage3Label = "Forum";
            resourceImage4Label = "Docs";
        }
    }

    public class CinemaProCamsBaseProductInfo : ProductInfo
    {
        public CinemaProCamsBaseProductInfo()
            : base()
        {
            name = "Cinema Pro Cams";
            keyImage = Resources.Load("ProCamsKeyImage") as Texture2D;
            headerText = "<size=16>Cinema Pro Cams</size>";
            header2Text = "<size=14>Film Lens & 3D Toolkit.</size>";
            bodyText = "Cinema Pro Cams is an industry standard toolbox to aid in the creation of accurate, real-world cinematic cameras inside of your Unity or project.";
            string suffix = EditorGUIUtility.isProSkin ? "_Pro" : "_Personal";
            resourceImage1 = Resources.Load("Cinema_Suite_Video" + suffix) as Texture2D;
            resourceImage2 = Resources.Load("Cinema_Suite_Store" + suffix) as Texture2D;
            resourceImage3 = Resources.Load("Cinema_Suite_Forums" + suffix) as Texture2D;
            resourceImage4 = Resources.Load("Cinema_Suite_Docs" + suffix) as Texture2D;

            resourceImage1Link = "https://youtu.be/Nx3gaSbLW0s";
            resourceImage2Link = "http://u3d.as/6N6";
            resourceImage3Link = "http://forum.unity3d.com/threads/cinema-pro-cams-released.238040/";
            resourceImage4Link = "http://www.cinema-suite.com/Documentation/CinemaProCams/Current/CinemaProCamsDocumentation.pdf";

            resourceImage1Label = "Video";
            resourceImage2Label = "Store";
            resourceImage3Label = "Forum";
            resourceImage4Label = "Docs";
        }
    }

    public class CinemaThemesBaseProductInfo : ProductInfo
    {
        public CinemaThemesBaseProductInfo()
            : base()
        {
            name = "Cinema Themes";
            keyImage = Resources.Load("ThemesKeyImage") as Texture2D;
            headerText = "<size=16>Cinema Themes</size>";
            header2Text = "<size=14>Get it Free!</size>";
            bodyText = "Cinema Themes is a collection of LUTs (Look Up Textures) that create a cinematic look and feel. Capture that perfect mood for your environment as you tell your story.";

            string suffix = EditorGUIUtility.isProSkin ? "_Pro" : "_Personal";
            resourceImage1 = Resources.Load("Cinema_Suite_Video" + suffix) as Texture2D;
            resourceImage2 = Resources.Load("Cinema_Suite_Store" + suffix) as Texture2D;
            resourceImage3 = Resources.Load("Cinema_Suite_Docs" + suffix) as Texture2D;

            resourceImage1Link = "https://youtu.be/QR2nWGzlrJo";
            resourceImage2Link = "http://u3d.as/8HZ";
            resourceImage3Link = "http://www.cinema-suite.com/Documentation/CinemaThemes/CinemaThemesDocumentation.pdf";

            resourceImage1Label = "Video";
            resourceImage2Label = "Store";
            resourceImage3Label = "Docs";
        }
    }
}