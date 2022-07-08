using System.Net;
namespace Nocturnal.Apis.qm.Example
{
    internal class Download_Images
    {
        internal static byte[] s_pageIcon { get; set; }
        internal static byte[] _ClipBoardIcon { get; set; }
        internal static byte[] _WorldIcon { get; set; }


        public Download_Images()
        {
            //I would recommend storing the images somewhere in something like base64 string or anything and then just read the file.
            //But for now we just going to download the images every time sense this is a button api example.
            using (var webclient = new WebClient())
            {
                //Here we storing the Data(Byte array) into some static props.
                s_pageIcon = webclient.DownloadData("https://nocturnal-client.xyz/Resources/Nocturnal%20logo.png");

                _ClipBoardIcon = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/clipboard.png");

                _WorldIcon = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/World.png");
            }

        }
    }
}
