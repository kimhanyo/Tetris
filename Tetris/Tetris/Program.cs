using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;

namespace Tetris
{
    //↓enum
    enum Tetris_BLOCK                                                               //테트리스 Enum (이차원 배열리스트안에 값에 따라 그려주기때문에 값을 가독성이 좋게 Enum으로 만들었습니다.)
    {
        VOID,       //빈공간
        BLOCK,      //블럭
        WALL        //벽
    }



    //↓static 클래스
    class C_static
    {
        //↓static 변수
        //--------------------------------------------------------------------------------------------------------------------------------
        private static int width = 10;                                                                   //맵의 너비
        private static int height = 20;                                                                  //맵의 높이
        private static int top_Point_max=4;
        public static List<List<Tetris_BLOCK>> Map_Tetris = new List<List<Tetris_BLOCK>>();              //리스트 안에 리스트를 사용해서 이차원 배열처럼 사용
        //--------------------------------------------------------------------------------------------------------------------------------

        //↓private로 묶인 width와 height를 읽기전용으로만 가져온다
        //--------------------------------------------------------------------------------------------------------------------------------
        public static int get_Width                                                 //맵의 너비를 읽기목적으로만 쓰기위해 만들었습니다.
        {
            get
            {
                return width;
            }
        }
        public static int get_Height                                                //맵의 높이를 읽기목적으로만 쓰기위해 만들었습니다.
        {
            get
            {
                return height;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------
    }



    //↓초기화 클래스
    class C_Init                                                                                    //초기화를위한 클래스
    {
        //↓초기화 메소드 (콘솔창의 크기 초기화 -> 테트리스 맵 초기화)
        //--------------------------------------------------------------------------------------------------------------------------------
        static public void Init()
        {
            Console.SetWindowSize(C_static.get_Width * 2 + 15, C_static.get_Height + 10);           //콘솔창 사이즈 조절(유니코드를 쓰기때문에 너비사이즈를 x2배 해주고 여백을 추가 했습니다.)
            Console.CursorVisible = false;                                                        //커서 안보이기

            for (int i = 0; i < C_static.get_Height; i++)                                          //리스트로 작성을 했기 때문에 틀을 만들어 놔야되서 전체 크기만큼 틀을 만듭니다.
            {
                C_static.Map_Tetris.Add(new List<Tetris_BLOCK>());                                 //Map_Tetris[i]에 리스트를 동적할당해서 이중포인터처럼 사용합니다.
                for (int j = 0; j < C_static.get_Width; j++)                                       //Map_Tetris[i]에 width만큼 크기를 잡아줍니다. 
                {                                                                                 //결과적으로 Map_Tetris[height,width]만큼의 사각형 맵 틀이 만들어집니다.          
                    C_static.Map_Tetris[i].Add(Tetris_BLOCK.VOID);
                }
            }

            for (int i = 0; i < C_static.get_Height; i++)                                          //Map의 양옆끝에 존재하는 벽을 넣어줍니다.
            {
                C_static.Map_Tetris[i][0] = Tetris_BLOCK.WALL;
                C_static.Map_Tetris[i][C_static.get_Width - 1] = Tetris_BLOCK.WALL;
            }

            for (int j = 0; j < C_static.get_Width; j++)                                           //Map의 바닥에 벽을 넣어줍니다.
            {
                C_static.Map_Tetris[C_static.get_Height - 1][j] = Tetris_BLOCK.WALL;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------
    }



    //↓Rander 클래스
    class C_Render
    {
        public static void Render()
        {
            for (int i = 0; i < C_static.get_Height; i++)
            {
                for (int j = 0; j < C_static.get_Width; j++)
                {
                    switch(C_static.Map_Tetris[i][j])
                    {
                        case Tetris_BLOCK.WALL:
                            Console.Write("▣");
                            break;
                        case Tetris_BLOCK.VOID:
                            Console.Write("□");
                            break;
                        case Tetris_BLOCK.BLOCK:
                            Console.Write("■");
                            break;
                        default:
                            Console.Write("Error!");
                            break;
                    }
                }
                Console.Write("\n");
            }
        }
    }



    //↓블럭세팅 클래스
    class C_Setting_Block
    {
        public void Setting_Block(int PosX,int PosY,Tetris_BLOCK block)
        {
            C_static.Map_Tetris[PosX][PosY] = block;
        }
    }



    //↓블럭컨트롤 클래스
    class C_ConTrol_Block
    {
        ConsoleKeyInfo? info = null;
        //protected void Input()
        //{
        //    if (Console.KeyAvailable)
        //    {
        //        ConsoleKeyInfo tempinfo = Console.ReadKey();
        //        info = tempinfo;

        //        if (info.Value.Key == ConsoleKey.D || info.Value.Key == ConsoleKey.RightArrow)
        //        {
        //            ++Posx;
        //        }

        //        else if (info.Value.Key == ConsoleKey.A || info.Value.Key == ConsoleKey.LeftArrow)
        //        {
        //            --Posx;
        //        }
        //    }
        //}
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            Tetris.C_Init.Init();
            Tetris.C_Render.Render();
        }
    }
}
