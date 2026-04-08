using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SharpShell.Attributes;
using SharpShell.SharpPreviewHandler;
using Markdig;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace CustomMdPreview
{
    [ComVisible(true)]
    [Guid("E2B6D440-62A8-4EF5-842E-7ECEDFDB2731")]
    [COMServerAssociation(AssociationType.Class, ".md")]
    [PreviewHandler]
    public class MarkdownPreviewHandler : SharpPreviewHandler
    {
        protected override PreviewHandlerControl DoPreview()
        {
            MarkdownPreviewControl control = new MarkdownPreviewControl();
            
            control.LoadFile(this.SelectedFilePath);
            
            return control;
        }
    }

    public class MarkdownPreviewControl : PreviewHandlerControl
    {
        private HtmlPanel _htmlPanel;

        public MarkdownPreviewControl()
        {
            this.BackColor = Color.White;
            
            _htmlPanel = new HtmlPanel();
            _htmlPanel.Dock = DockStyle.Fill;
            _htmlPanel.BackColor = Color.White;
            
            // Základní CSS styly nadefinované přímo pro HtmlPanel
            _htmlPanel.BaseStylesheet = @"
                body { font-family: 'Segoe UI', sans-serif; padding: 20px; color: #333; }
                code { background-color: #f4f4f4; padding: 2px 4px; }
                pre { background-color: #f4f4f4; padding: 10px; border-left: 3px solid #ccc; }
                blockquote { color: #666; margin-left: 10px; }
                table { border-collapse: collapse; }
                th, td { border: 1px solid #ccc; padding: 5px; }
            ";
            
            this.Controls.Add(_htmlPanel);
        }

        public void LoadFile(string filePath)
        {
            try
            {
                string mdContent = File.ReadAllText(filePath);
                
                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
                    
                string htmlContent = Markdown.ToHtml(mdContent, pipeline);

                // Nyní vkládáme HTML čistě a přímo, bez meta hlaviček pro prohlížeče
                _htmlPanel.Text = $"<html><body>{htmlContent}</body></html>";
            }
            catch (Exception ex)
            {
                _htmlPanel.Text = $"<html><body><h3 style='color:red;'>Chyba:</h3><p>{ex.Message}</p></body></html>";
            }
        }
    }
}