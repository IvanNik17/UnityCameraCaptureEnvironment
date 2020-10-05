
using UnityEngine;
using System.Collections;
using UnityEditor;

public class CinemaThemesProductInfo : CinemaSuite.CinemaThemesBaseProductInfo
{
    public CinemaThemesProductInfo()
    {
        name = "Cinema Themes";
        version = "2.0.0.2";
        installed = true;

        headerText = "<size=16>Cinema Themes</size>";
        header2Text = string.Format("<size=14><b>v{0}</b> detected.</size>", version);
        bodyText = "Thank you for downloading Cinema Themes! We appreciate your support, and hope you enjoy using our collection of VFX themes for Unity!\n\nCheck out the helpful links on the left to get going.\n\nIf you have a chance, please leave us a review on the Asset Store.";

        string suffix = EditorGUIUtility.isProSkin ? "_Pro" : "_Personal";
        resourceImage1 = Resources.Load("Cinema_Suite_Docs" + suffix) as Texture2D;
        resourceImage2 = Resources.Load("Cinema_Suite_Forums" + suffix) as Texture2D;
        resourceImage3 = Resources.Load("Cinema_Suite_Tips" + suffix) as Texture2D;
        resourceImage4 = Resources.Load("Cinema_Suite_Video" + suffix) as Texture2D;

        resourceImage1Link = "http://www.cinema-suite.com/Documentation/CinemaThemes/CinemaThemesDocumentation.pdf";
        resourceImage2Link = "http://cinema-suite.com/forum/viewforum.php?f=26";
        resourceImage3Link = "https://youtu.be/vfAw4vdxemg";
        resourceImage4Link = "https://youtu.be/uF0Ihe8Jisw";

        resourceImage1Label = "Docs";
        resourceImage2Label = "Forum";
        resourceImage3Label = "Tips";
        resourceImage4Label = "Tutorial";

        assetStorePage = "http://u3d.as/8HZ";
    }
}
