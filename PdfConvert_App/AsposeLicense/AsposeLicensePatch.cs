using HarmonyLib;
using System.Diagnostics;
using System.Reflection;
using System.Xml;

namespace PdfConvert_App.AsposeLicense
{
    public class AsposeLicensePatch : IDisposable
    {
        private Harmony harmony;
        private const string NEW_EXP = "20591231";

        public AsposeLicensePatch()
        {
            harmony = Harmony.CreateAndPatchAll(this.GetType(), nameof(AsposeLicensePatch));
        }

        static Boolean StackInAspose()
        {
            var stacktrace = new StackTrace();
            var stackFrames = stacktrace.GetFrames();

            if (stackFrames == null) return false;
            var isAsposeLicense = stackFrames.Any(r => r.HasMethod() && r.GetMethod().Name == "SetLicense" && r.GetMethod().DeclaringType != null && (r.GetMethod().Module.ScopeName.StartsWith("Aspose.") || r.GetMethod().Module.ScopeName.StartsWith("GroupDocs.")));

            return isAsposeLicense;
        }

        ~AsposeLicensePatch()
        {
            this.Dispose(false);
        }

        private bool _isDisposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._isDisposed)
            {
                if (disposing)
                {
                    harmony?.UnpatchSelf();
                }
                this._isDisposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        // https://www.52pojie.cn/thread-1737340-1-1.html
        [HarmonyPatch(typeof(XmlElement), "InnerText", MethodType.Getter)]
        [HarmonyPostfix]
        private static void Postfix_XmlElement_InnerText_Getter(XmlElement __instance, ref String __result, MethodInfo __originalMethod)
        {
            if (StackInAspose())
            {
                if (__instance.Name == "SubscriptionExpiry")
                {
                    __result = NEW_EXP;
                }
            }
        }

        [HarmonyPatch(typeof(XmlReader), "ReadString")]
        [HarmonyPostfix]
        private static void Postfix_XmlReader_ReadString(XmlReader __instance, ref String __result, MethodInfo __originalMethod)
        {
            if (StackInAspose())
            {
                if (__instance.LocalName == "SubscriptionExpiry")
                {
                    __result = NEW_EXP;
                }
            }
        }

        [HarmonyPatch(typeof(String), "IndexOf", new Type[] { typeof(String) })]
        [HarmonyPostfix]
        static void PostFix_String_IndexOf(String __instance, String value, ref Int32 __result, MethodInfo __originalMethod)
        {
            if (StackInAspose())
            {
                if (__result != -1) return;
                if (value == NEW_EXP)
                {
                    __result = 0;
                }
            }
        }

        [HarmonyPatch(typeof(XmlCharacterData), "Data", MethodType.Getter)]
        [HarmonyPostfix]
        private static void Postfix_XmlText_Data_Getter(XmlCharacterData __instance, ref string __result, MethodInfo __originalMethod)
        {
            if (StackInAspose())
            {
                var stacks = new StackTrace().GetFrames();
                if (stacks.Any(s => s.GetMethod().Name.StartsWith("get_OuterXml")))
                {
                    return;
                }
                var parentNod = __instance.ParentNode;
                if (parentNod == null) return;
                if (parentNod.Name == "SubscriptionExpiry" || parentNod.Name == "LicenseExpiry")
                {
                    __result = NEW_EXP;
                }
            }
        }
    }
}
