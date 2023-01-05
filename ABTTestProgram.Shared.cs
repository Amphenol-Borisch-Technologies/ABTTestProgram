﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using ABTTestLibrary;
using ABTTestLibrary.Config;
using ABTTestLibrary.Instruments;
using ABTTestLibrary.TestSupport;

// Place all Test methods, convenience methods & classes, comments applicable to multiple Groups in this file.
// Do not place them in any other file, as methods & classes must be unique within a namespace.
//
namespace ABTTestProgram {
    internal sealed partial class ABTTests {
        private static DialogResult _dialogResult;
        private static Type _type;
        private static MethodInfo _methodInfo;
        private static (Int32 U6, Int32 U7) _CRCsPreCalibration = (U6: 0x050C, U7: 0x05FE);
        static ABTTests() { }

        public static String RunTestMethod(Test test, Dictionary<String, Instrument> instruments) {
            // https://stackoverflow.com/questions/540066/calling-a-function-from-a-string-in-c-sharp
            // https://www.codeproject.com/Articles/19911/Dynamically-Invoke-A-Method-Given-Strings-with-Met
            // Indirectly override TestForm's abstract RunTest() method.  Necessary because implementing RunTest()
            // in ABTTestLibrary's RunTest() method would necessiate in having a reference to this
            // client Test project, and we don't want that.
            // We instead want this client Test project to reference the ABTTestLibray, and ABTTestLibary
            // to be blissfully ignorant of this client Test project.
            // TODO: Obsolete this method, by invoking Test methods via Reflection across classes,
            // originating from ABTTestProgram.Form.cs method RunTest() instead of delegating to this
            // RunTestMethod().  Thoughts below.
            // https://stackoverflow.com/questions/34523717/how-to-get-namespace-class-methods-and-its-arguments-with-reflection
            // https://stackoverflow.com/questions/79693/getting-all-types-in-a-namespace-via-reflection
            _type = typeof(ABTTests);
            _methodInfo = _type.GetMethod(test.ID, BindingFlags.Static | BindingFlags.NonPublic);
            return (String)_methodInfo.Invoke(null, new object[] { test, instruments });
        }

        private static (Int32 U6, Int32 U7) GetCRCsPreCalibration() {
            return _CRCsPreCalibration;
        }

        internal static String T0(Test test, Dictionary<String, Instrument> instruments) {
            // Implementation unspecified :-)
            return "63";
        }

        internal static String T1(Test test, Dictionary<String, Instrument> instruments) {
            // Implementation unspecified :-)
            return "5.12";
        }

        internal static String T2(Test test, Dictionary<String, Instrument> instruments) {
            // Implementation unspecified :-)
            return "3.29";
        }

        internal static String T3(Test test, Dictionary<String, Instrument> instruments) {
            // Implementation unspecified :-)
            return "0.9";
        }

        internal static String T4(Test test, Dictionary<String, Instrument> instruments) {
            // Implementation unspecified :-)
            return "2.5";
        }

        internal static String T5(Test test, Dictionary<String, Instrument> instruments) {
            // Implementation unspecified :-)
            return "1.75";
        }

        internal static String T6(Test test, Dictionary<String, Instrument> instruments) {
            // Implementation unspecified :-)
            return "1.0001E7";
        }

        internal static String T9(Test test, Dictionary<String, Instrument> instruments) {
            // Implementation unspecified :-)
            return EventCodes.PASS; // UUT is happy!
        }
    }
}
