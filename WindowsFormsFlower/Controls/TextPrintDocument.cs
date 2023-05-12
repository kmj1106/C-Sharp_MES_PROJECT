using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

namespace WindowsFormsFlower
{
	/// <summary>
	/// Class1에 대한 요약 설명입니다.
	/// </summary>
	public class TextPrintDocument: PrintDocument 
	{
		private Font printFont             = null;
		private StringReader streamToPrint = null;
		private string overflowText        = null;

		public TextPrintDocument(StringReader streamToPrint, Font printFont) : base ()  
		{
			this.streamToPrint = streamToPrint ;
			this.printFont = printFont;
		}

		//PrintDocument 클래스로부터 파생된 클래스의 Print메서드가 호출되면 
		//프린팅에 필요한 초기화 내용을 기술하는 메서드.
		protected override void OnBeginPrint(PrintEventArgs ev) 
		{
			base.OnBeginPrint(ev) ;

			overflowText = null;
		}

		//PrintDocument 클래스로부터 파생된 클래스의 Print메서드가 호출되면 
		//실제로 프린팅하는 내용을 기술하는 메서드.
		protected override void OnPrintPage(PrintPageEventArgs ev) 
		{

			base.OnPrintPage(ev) ;

			float lpp = 0 ;
			float yPos =  0 ;
			int count = 0 ;
			float leftMargin = ev.MarginBounds.Left;
			float topMargin = ev.MarginBounds.Top;
			String line=null;

			//Work out the number of lines per page
			//Use the MarginBounds on the event to do this
			lpp = ev.MarginBounds.Height  / printFont.GetHeight(ev.Graphics) ;

			//If we have overflow text from the last page deal with that first
			while (count < lpp && overflowText != null) 
			{
				yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
				int linesPrinted = PrintLine(ev,overflowText, yPos);
				count += linesPrinted;
			}

			//Now iterate over the file printing out each line
			//Check count first so that we don't read line that we won't print
			while (count < lpp && ((line=streamToPrint.ReadLine()) != null)) 
			{
				yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
				int linesPrinted = PrintLine(ev,line, yPos);
				count += linesPrinted;
			}

			//If we have more lines then print another page
			if (line != null)
				ev.HasMorePages = true ;
			else
				ev.HasMorePages = false ;
		}


		private int PrintLine(PrintPageEventArgs e, string text, float yStartPos) 
		{
			Graphics graphics = e.Graphics;
			Margins margins = e.PageSettings.Margins;
			StringFormat format = new StringFormat();
			int lines;
			int characters;
			RectangleF rectangle = new RectangleF(margins.Left,
				yStartPos,
				e.MarginBounds.Width,
				e.MarginBounds.Height);

			graphics.MeasureString(text, printFont, rectangle.Size, format, out characters, out lines);

			//If characters is less than string.length then we can't fit the whole
			//paragraph on the page so print what we can and store the rest for the
			//next page
			if (characters < text.Length) 
			{
				overflowText = text.Substring(characters);
			} 
			else 
			{
				overflowText = null;
			}

			graphics.DrawString(text, printFont, Brushes.Black, rectangle, format);


			//Cope with empty lines
			if (lines == 0 )
				lines = 1;

			return lines;
		}

	}
}
