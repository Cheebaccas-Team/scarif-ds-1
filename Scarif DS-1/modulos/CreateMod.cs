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

        public void RemovePage(string filePath, string filename, int pageNumber)
        {
            //Remove a página indica no ficheiro dado
            // Open the file
            PdfDocument inputDocument = PdfReader.Open(Path.Combine(filePath, filename), PdfDocumentOpenMode.Import);

            if (pageNumber > inputDocument.PageCount || pageNumber <= 0)
            {
                throw new ArgumentException("Número da página a remover é inválido.");
            }
            else
            {
                // Create new document
                PdfDocument outputDocument = new PdfDocument();
                outputDocument.Version = inputDocument.Version;
                outputDocument.Info.Title = inputDocument.Info.Title;
                outputDocument.Info.Creator = inputDocument.Info.Creator;
                for (int idx = 0; idx < inputDocument.PageCount; idx++)
                {
                    // Add the page 
                    if (pageNumber == idx + 1)
                    {
                        //página a ignorar
                    }
                    else
                    {
                        outputDocument.AddPage(inputDocument.Pages[idx]);
                    }
                }
            }

            outputDocument.Save(Path.Combine(filePath, filename));
        }
    }*/
    }
}