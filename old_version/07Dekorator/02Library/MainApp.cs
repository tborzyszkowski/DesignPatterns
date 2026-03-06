using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Library {
	class MainApp {
		static void Main(string[] args) {

			Book book = new Book("Worley", "Inside ASP.NET", 10);
			book.Display();

			Video video = new Video("Spielberg", "Jaws", 23, 92);
			video.Display();

			Console.WriteLine("\nMaking video borrowable:");

			Borrowable borrowvideo = new Borrowable(video);
			borrowvideo.BorrowItem("Customer #1");
			borrowvideo.BorrowItem("Customer #2");
			borrowvideo.Display();

			borrowvideo.ReturnItem("Customer #1");
			borrowvideo.Display();
		}
	}
}
