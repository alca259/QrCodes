namespace MediaFrameQrProcessing.ZXing
{
    using global::ZXing;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Storage.Streams;
    using ZXing;

    public static class ZXingBarcodeDecoder
    {
        static BarcodeReader barcodeReader;

        static ZXingBarcodeDecoder()
        {
            barcodeReader = new BarcodeReader();
            barcodeReader.Options.PureBarcode = false;
            barcodeReader.Options.Hints.Add(DecodeHintType.TRY_HARDER, true);
            barcodeReader.Options.PossibleFormats = new BarcodeFormat[] { BarcodeFormat.All_1D };

            barcodeReader.Options.TryHarder = true;
        }

        public static Result DecodeBufferToCode(byte[] buffer, int width, int height, BitmapFormat bitmapFormat)
        {
            var zxingResult = barcodeReader.Decode(buffer, width, height, bitmapFormat);
            return (zxingResult);
        }

        public static Result DecodeBufferToCode(IBuffer buffer, int width, int height, BitmapFormat bitmapFormat)
        {
            return (DecodeBufferToCode(buffer.ToArray(), width, height, bitmapFormat));
        }
    }
}