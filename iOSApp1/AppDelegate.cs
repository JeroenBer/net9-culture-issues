using System.Globalization;
using System.Text;

namespace iOSApp1;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        var testResults = RunTests();
        
        // create a UIViewController with a single UILabel
        var vc = new UIViewController();
        vc.View!.AddSubview(new UITextView(Window!.Frame.Inset(0, 100))
        {
            BackgroundColor = UIColor.SystemBackground,
            TextAlignment = UITextAlignment.Center,
            Text = testResults,
            AutoresizingMask = UIViewAutoresizing.All,
        });
        Window.RootViewController = vc;

        // make the window visible
        Window.MakeKeyAndVisible();

        return true;
    }

    string RunTests()
    {
        var sb = new StringBuilder();
        var cultures = new List<string> { "en-US", "en", "nl", "de", "fr", "ja", "ch" };

        foreach (var culture in cultures)
        {
            var testResult = RunTest(culture);

            sb.AppendLine(testResult);
        }
        
        return sb.ToString();
    }

    string RunTest(string culture)
    {
        CultureInfo.CurrentCulture = new CultureInfo("nl");
        
        // TEST, Expecting -1, getting 0
        var x = "";
        var i = x.IndexOf(" ");
        
        

        return $"Culture: {culture}, i={i}";
    }
}