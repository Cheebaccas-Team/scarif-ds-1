namespace Scarif_DS_1
{
    public class CreateMod
    {
        /*
        public void SplitDocument(string filePath, string filename, string outputPath)
        {
            //Dado um ficheiro com n páginas devolve n ficheiros com 1 página na path de saída
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Open the file
            PdfDocument inputDocument = PdfReader.Open(Path.Combine(filePath, filename), PdfDocumentOpenMode.Import);

            string name = Path.GetFileNameWithoutExtension(filename);

            for (int idx = 0; idx < inputDocument.PageCount; idx++)
            {
                // Create new document
                PdfDocument outputDocument = new PdfDocument();
                outputDocument.Version = inputDocument.Version;
                outputDocument.Info.Title = String.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title);
                outputDocument.Info.Creator = inputDocument.Info.Creator;

                // Add the page and save it
                outputDocument.AddPage(inputDocument.Pages[idx]);
                outputDocument.Save(Path.Combine(outputPath,
                    String.Format("{0} - Page {1}_tempfile.pdf", name, idx + 1)));
            }
        }
    }*/
    }
}