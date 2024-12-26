using Aspose.Pdf.Operators;
using PdfConvert_App.AsposeLicense;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace PdfConvert_App
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// AsposeCell��Key
        /// </summary>
        private readonly string AsposeKey =
                "PExpY2Vuc2U+DQogIDxEYXRhPg0KICAgIDxMaWNlbnNlZFRvPkFzcG9zZSBTY290bGFuZCB" +
                "UZWFtPC9MaWNlbnNlZFRvPg0KICAgIDxFbWFpbFRvPmJpbGx5Lmx1bmRpZUBhc3Bvc2UuY2" +
                "9tPC9FbWFpbFRvPg0KICAgIDxMaWNlbnNlVHlwZT5EZXZlbG9wZXIgT0VNPC9MaWNlbnNlV" +
                "HlwZT4NCiAgICA8TGljZW5zZU5vdGU+TGltaXRlZCB0byAxIGRldmVsb3BlciwgdW5saW1p" +
                "dGVkIHBoeXNpY2FsIGxvY2F0aW9uczwvTGljZW5zZU5vdGU+DQogICAgPE9yZGVySUQ+MTQ" +
                "wNDA4MDUyMzI0PC9PcmRlcklEPg0KICAgIDxVc2VySUQ+OTQyMzY8L1VzZXJJRD4NCiAgIC" +
                "A8T0VNPlRoaXMgaXMgYSByZWRpc3RyaWJ1dGFibGUgbGljZW5zZTwvT0VNPg0KICAgIDxQc" +
                "m9kdWN0cz4NCiAgICAgIDxQcm9kdWN0PkFzcG9zZS5Ub3RhbCBmb3IgLk5FVDwvUHJvZHVj" +
                "dD4NCiAgICA8L1Byb2R1Y3RzPg0KICAgIDxFZGl0aW9uVHlwZT5FbnRlcnByaXNlPC9FZGl" +
                "0aW9uVHlwZT4NCiAgICA8U2VyaWFsTnVtYmVyPjlhNTk1NDdjLTQxZjAtNDI4Yi1iYTcyLT" +
                "djNDM2OGYxNTFkNzwvU2VyaWFsTnVtYmVyPg0KICAgIDxTdWJzY3JpcHRpb25FeHBpcnk+M" +
                "jAxNTEyMzE8L1N1YnNjcmlwdGlvbkV4cGlyeT4NCiAgICA8TGljZW5zZVZlcnNpb24+My4w" +
                "PC9MaWNlbnNlVmVyc2lvbj4NCiAgICA8TGljZW5zZUluc3RydWN0aW9ucz5odHRwOi8vd3d" +
                "3LmFzcG9zZS5jb20vY29ycG9yYXRlL3B1cmNoYXNlL2xpY2Vuc2UtaW5zdHJ1Y3Rpb25zLm" +
                "FzcHg8L0xpY2Vuc2VJbnN0cnVjdGlvbnM+DQogIDwvRGF0YT4NCiAgPFNpZ25hdHVyZT5GT" +
                "zNQSHNibGdEdDhGNTlzTVQxbDFhbXlpOXFrMlY2RThkUWtJUDdMZFRKU3hEaWJORUZ1MXpP" +
                "aW5RYnFGZkt2L3J1dHR2Y3hvUk9rYzF0VWUwRHRPNmNQMVpmNkowVmVtZ1NZOGkvTFpFQ1R" +
                "Hc3pScUpWUVJaME1vVm5CaHVQQUprNWVsaTdmaFZjRjhoV2QzRTRYUTNMemZtSkN1YWoyTk" +
                "V0ZVJpNUhyZmc9PC9TaWduYXR1cmU+DQo8L0xpY2Vuc2U+";
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textPdfPath.Text))
                {
                    MessageBox.Show($"����д��Ҫת����Pdf�ļ�·����ַ��", "������ʾ");
                    return;
                }
                if (!string.IsNullOrWhiteSpace(textPdfPath.Text) && !File.Exists(textPdfPath.Text))
                {
                    MessageBox.Show($"��д��Pdf�ļ�·����ַ�Ҳ�����Ӧ���ļ���", "������ʾ");
                    return;
                }
                if (string.IsNullOrWhiteSpace(textFilePath.Text))
                {
                    MessageBox.Show($"����д�����ļ���ַ·����", "������ʾ");
                    return;
                }
                if (!string.IsNullOrWhiteSpace(textFilePath.Text) && File.Exists(textFilePath.Text))
                {
                    MessageBox.Show($"��д�������ļ���ַ·���Ѵ��ڶ�Ӧ�ļ�����������д��", "������ʾ");
                    return;
                }
                btn_Generate.Enabled = false;
                var changeText = comBoxFileType.Text;
                if (!string.IsNullOrWhiteSpace(changeText))
                {
                    using (new AsposeLicensePatch())
                    {
                        new Aspose.Pdf.License().SetLicense(new MemoryStream(Convert.FromBase64String(AsposeKey)));
                        var document = new Aspose.Pdf.Document(textPdfPath.Text);
                        if (changeText.ToLower() == "Word".ToLower())
                        {
                            Aspose.Pdf.DocSaveOptions options = new Aspose.Pdf.DocSaveOptions();
                            document.Save($"{Path.Combine(textFilePath.Text, Path.GetFileNameWithoutExtension(textPdfPath.Text))}.docx", options);
                        }
                        else
                        {
                            Aspose.Pdf.ExcelSaveOptions options = new Aspose.Pdf.ExcelSaveOptions();
                            options.Format = Aspose.Pdf.ExcelSaveOptions.ExcelFormat.XLSX;
                            options.MinimizeTheNumberOfWorksheets = true;
                            options.ExtractOcrSublayerOnly = true;
                            document.Save($"{Path.Combine(textFilePath.Text, Path.GetFileNameWithoutExtension(textPdfPath.Text))}.xlsx", options);
                        }
                    }
                    MessageBox.Show($"���ɳɹ���", "�ɹ���ʾ");
                }
                else
                {
                    MessageBox.Show($"δ��ȡ��ѡ����ļ����ͣ�", "������ʾ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"����ʧ�ܣ�{ex.Message} ����ϵ����Ա��", "������ʾ");
            }
            finally
            {
                btn_Generate.Enabled = true;
            }
        }
    }
}
