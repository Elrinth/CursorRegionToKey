using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MouseCursorScreenMapProgram
{
  public partial class CursorRegionToKey : Form
  {
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardInput
    {
      public ushort wVk;
      public ushort wScan;
      public uint dwFlags;
      public uint time;
      public IntPtr dwExtraInfo;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseInput
    {
      public int dx;
      public int dy;
      public uint mouseData;
      public uint dwFlags;
      public uint time;
      public IntPtr dwExtraInfo;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct HardwareInput
    {
      public uint uMsg;
      public ushort wParamL;
      public ushort wParamH;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
      [FieldOffset(0)] public MouseInput mi;
      [FieldOffset(0)] public KeyboardInput ki;
      [FieldOffset(0)] public HardwareInput hi;
    }
    public struct Input
    {
      public int type;
      public InputUnion u;
    }
    [Flags]
    public enum InputType
    {
      Mouse = 0,
      Keyboard = 1,
      Hardware = 2
    }

    [Flags]
    public enum KeyEventF
    {
      KeyDown = 0x0000,
      ExtendedKey = 0x0001,
      KeyUp = 0x0002,
      Unicode = 0x0004,
      Scancode = 0x0008
    }

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

    [DllImport("user32.dll")]
    private static extern IntPtr GetMessageExtraInfo();

    //DateTime lastTime = DateTime.Now;
    //int refreshEllapse = (int)1000 / 10;
    private Rectangle rectangle = new Rectangle(0,0,0,0);
    private Rectangle cursorPosition = new Rectangle(0, 0, 16, 16);
    private bool pDown = false;
    private bool pUp = false;
    private bool pLeft = false;
    private bool pRight = false;

    const int VK_UP = 0x26; //up key
    const int VK_DOWN = 0x28;  //down key
    const int VK_LEFT = 0x25;
    const int VK_RIGHT = 0x27;

    const ushort K_S = 0x1F;
    const ushort K_W = 0x11;
    const ushort K_A = 0x1E;
    const ushort K_D = 0x20;
    
    const ushort K_UP = 0xC8;
    const ushort K_LEFT = 0xCB;
    const ushort K_RIGHT = 0xCD;
    const ushort K_DOWN = 0xD0;

    const uint KEYEVENTF_KEYUP = 0x0002;
    const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
    const uint WM_KEYDOWN = 0x0100;
    const uint WM_KEYUP = 0x0101;
    protected Process p = null;

    public CursorRegionToKey()
    {
      InitializeComponent();
      rectangle = new Rectangle(this.ClientSize.Width / 2 - (this.ClientSize.Width / 4), this.ClientSize.Height / 2 - (this.ClientSize.Height / 4), (this.ClientSize.Width / 2), (this.ClientSize.Height / 2));
      
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
      g.Clear(BackColor);
      Pen pen1 = new Pen(Color.Black, 1);
      //surface.DrawLine(pen1, 0, 0, this.ClientSize.Width / 2, this.ClientSize.Height);
      g.DrawRectangle(pen1, rectangle);

      Cursor.Draw(g, cursorPosition);

      mouseX.Text = "mx: " + Cursor.Position.X;
      mouseY.Text = "my: " + Cursor.Position.Y;
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      // recalculate the form size...
      rectangle = new Rectangle(this.ClientSize.Width / 2 - (this.ClientSize.Width / 4), this.ClientSize.Height / 2 - (this.ClientSize.Height / 4), (this.ClientSize.Width / 2), (this.ClientSize.Height / 2));
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      var screenSize = Screen.PrimaryScreen.Bounds.Size;
      // calculate mouse poosition:
      float resultX = (float)Cursor.Position.X / (float)screenSize.Width;
      float resultY = (float)Cursor.Position.Y / (float)screenSize.Height;
      cursorPosition.X = (int)(resultX * this.ClientSize.Width);
      cursorPosition.Y = (int)(resultY * this.ClientSize.Height);

      // check directions:
      checkDirections();

      sendKeyboardCommands();

      Invalidate();
    }

    private void sendMoveCommand(ushort iKey, KeyEventF eventF)
    {
      Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = iKey,
                        dwFlags = (uint)(eventF | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

      SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    private void sendKeyboardCommands()
    {
      if (pDown)
      {
        sendMoveCommand(K_S, KeyEventF.KeyDown);
      }
      if (pUp)
      {
        sendMoveCommand(K_W, KeyEventF.KeyDown);
      }
      if (pLeft)
      {
        sendMoveCommand(K_A, KeyEventF.KeyDown);
      }

      if (pRight)
      {
        sendMoveCommand(K_D, KeyEventF.KeyDown);
      }
    }

    private void checkDirections()
    {
      // down
      if (cursorPosition.Y > rectangle.Y + rectangle.Height)
      {
        if (pDown == false)
        {
          pDown = true;
          labelBottom.Font = new Font(labelBottom.Font, System.Drawing.FontStyle.Bold);
        }
      }
      else
      {
        if (pDown == true)
        {
          pDown = false;
          labelBottom.Font = new Font(labelBottom.Font, System.Drawing.FontStyle.Regular);
          sendMoveCommand(K_S, KeyEventF.KeyUp);
        }
      }


      // up
      if (cursorPosition.Y < rectangle.Y)
      {
        if (pUp == false)
        {
          pUp = true;
          labelTop.Font = new Font(labelTop.Font, System.Drawing.FontStyle.Bold);
        }
      }
      else
      {
        if (pUp == true)
        {
          pUp = false;
          labelTop.Font = new Font(labelTop.Font, System.Drawing.FontStyle.Regular);
          sendMoveCommand(K_W, KeyEventF.KeyUp);
        }
      }

      // left
      if (cursorPosition.X < rectangle.X)
      {
        if (pLeft == false)
        {
          pLeft = true;
          labelLeft.Font = new Font(labelLeft.Font, System.Drawing.FontStyle.Bold);
        }
      }
      else
      {
        if (pLeft == true)
        {
          pLeft = false;
          labelLeft.Font = new Font(labelLeft.Font, System.Drawing.FontStyle.Regular);
          sendMoveCommand(K_A, KeyEventF.KeyUp);
        }
      }

      // right
      if (cursorPosition.X > rectangle.X + rectangle.Width)
      {
        if (pRight == false)
        {
          pRight = true;
          labelRight.Font = new Font(labelRight.Font, System.Drawing.FontStyle.Bold);
        }
      }
      else
      {
        if (pRight == true)
        {
          pRight = false;
          labelRight.Font = new Font(labelRight.Font, System.Drawing.FontStyle.Regular);
          sendMoveCommand(K_D, KeyEventF.KeyUp);
        }
      }
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void CursorRegionToKey_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Escape)
      {
        this.Close();
      }
    }
  }
}
