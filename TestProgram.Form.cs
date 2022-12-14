using System;
using System.Collections.Generic;
using System.Threading;
using TestLibrary;
using TestLibrary.Config;
using TestLibrary.Instruments;

namespace TestProgram {
    internal sealed class TestProgramForm : TestLibraryForm {
        internal TestProgramForm() : base(Properties.Resources.Amphenol) {
            // NOTE: Change base constructor's Icon as applicable, depending on customer.
            // https://stackoverflow.com/questions/40933304/how-to-create-an-icon-for-visual-studio-with-just-mspaint-and-visual-studio
        }

        protected override String RunTest(Test test, Dictionary<String, Instrument> instruments, CancellationToken cancellationToken) {
            // https://stackoverflow.com/questions/540066/calling-a-function-from-a-string-in-c-sharp
            // https://www.codeproject.com/Articles/19911/Dynamically-Invoke-A-Method-Given-Strings-with-Met
            // Override TestForm's abstract RunTest() method.  Necessary because implementing RunTest()
            // in TestLibrary's RunTest() method would necessiate in having a reference to this
            // client Test project, and we don't want that.
            //  - We instead want this client Test project to reference the TestLibrray, but TestLibrary
            //    be blissfully ignorant of this client Test project.
            //  - Use Reflection's MethodInfo.Invoke to invoke the correct test method.
            //  - This is performed in the TestProgram.Shared.cs file, in partial class TestProgramTests,
            //    method RunTestMethod.
            //  - It's not performed here because this TestForm class would then have to be extended
            //    to the multiple Tests files comprising partial class TestProgramTests, which would
            //    not be pretty.
            return TestProgramTests.RunTestMethod(test, instruments, cancellationToken);
        }
    }
}
