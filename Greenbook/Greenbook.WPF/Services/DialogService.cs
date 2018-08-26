using CSharpFunctionalExtensions;
using Greenbook.Services;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Win32;

namespace Greenbook.WPF.Services
{
    public class DialogService : IDialogService
    {
        public Result<string> Open()
        {
            return Result.Ok(ShowDialog(new OpenFileDialog()));
        }

        public Result<string> Save()
        {
            return Result.Ok(ShowDialog(new SaveFileDialog()));
        }

        private static string ShowDialog(FileDialog fileDialog)
        {
            Guard.ArgumentNotNull(fileDialog, nameof(fileDialog));

            var result = fileDialog.ShowDialog();

            return result == true
                ? fileDialog.FileName
                : string.Empty;
        }
    }
}