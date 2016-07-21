#include<iostream>
#include<direct.h>
#include"Snake_Class.h"

#define _max(ID) --snake.ID_option < ID_1?ID : snake.ID_option
#define _min(ID) ++snake.ID_option > ID?ID_1 : snake.ID_option

//���ӹ���
LRESULT CALLBACK _HookProc(int, WPARAM, LPARAM);

void Wall();       //��ǽ����
void Frame();      //������
void initialize_();//��ʼ���߽ṹ����

Snake_data snake;
Snake_class csnake(&snake);
static HANDLE handle;  //����̨���
//����̨��Ϣ�ṹ
static CONSOLE_SCREEN_BUFFER_INFO info;

int main(){
	using namespace std;
	//��ȡ������������
	handle = GetStdHandle(STD_OUTPUT_HANDLE);
	//��ȡ�����Ϣ����Ҫ�ǻ�������С��
	GetConsoleScreenBufferInfo(handle, &info);
	initialize_();
	_mkdir("d://SnakeRecord"); //����Ŀ¼

	CONSOLE_CURSOR_INFO cursor;           //���ṹ 
	cursor.dwSize = 10;
	cursor.bVisible = 0;                  //0Ϊ���ع��
	SetConsoleCursorInfo(handle, &cursor);//�������ع�꺯�� 

	//csnake.ShowMenu();
	HHOOK hook;
	MSG msg;
	//��Ӧ�Ĺ�������Ӧ�Ĺ��̺���MSDN�пɿ�����װ���̹��� 
	hook = SetWindowsHookEx(WH_KEYBOARD_LL, _HookProc, GetModuleHandle(NULL), 0);
	while (1){
		//�ж����Ƿ񻹻���
		Wall();
		if (!snake.state && snake.ID_interface == ID_2){
			//csnake.Die();
			snake.ID_interface = ID_4;
			Frame();
		}
		if (snake.ID_interface == ID_2){
			csnake.StartGame();
			Sleep(snake.rank);
		}
		if (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE)){//ѭ��������Ϣ
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	UnhookWindowsHookEx(hook);    //ж�ع��� 
	return 0;
}

//���平�ӹ��̣�δ��ɣ�
LRESULT CALLBACK _HookProc(int message, WPARAM wParam, LPARAM lParam){
	//�ж��Ƿ��𰴼���Ϣ
	if (wParam == WM_KEYUP){
		bool state = true;
		switch (((LPKBDLLHOOKSTRUCT)lParam)->vkCode){//lParam:ָ��һ���ṹ 
			//�����ϼ�
		case VK_UP:
			switch (snake.ID_interface){
			case ID_1:
				snake.Flag = true;
				csnake.ShowMenu();
				snake.Flag = false;
				snake.ID_option = _max(ID_5);
				csnake.ShowMenu();
				break;
			case ID_2:
				if (snake.key != VK_DOWN && snake.key != VK_UP){
					snake.key = VK_UP;
				}
				break;
			case ID_5:
				snake.Flag = true;
				csnake.ShowRank();
				snake.ID_option = _max(ID_3);
				snake.Flag = false;
				csnake.ShowRank();
				break;
			case ID_6:
				snake.Flag = true;
				csnake.ShowRecord();
				snake.ID_option = _max(ID_6);
				snake.Flag = false;
				csnake.ShowRecord();
				break;
			}
			break;
			//�����¼�
		case VK_DOWN:
			switch (snake.ID_interface){
			case ID_1:
				snake.Flag = true;
				csnake.ShowMenu();
				snake.Flag = false;
				snake.ID_option = _min(ID_5);
				csnake.ShowMenu();
				break;
			case ID_2:
				if (snake.key != VK_UP && snake.key != VK_DOWN){
					snake.key = VK_DOWN;
				}
				break;
			case ID_5:
				snake.Flag = true;
				csnake.ShowRank();
				snake.ID_option = _min(ID_3);
				snake.Flag = false;
				csnake.ShowRank();
				break;
			case ID_6:
				snake.Flag = true;
				csnake.ShowRecord();
				snake.ID_option = _min(ID_6);
				snake.Flag = false;
				csnake.ShowRecord();
				break;
			}
			break;
			//�������
		case VK_LEFT:
			switch (snake.ID_interface){
			case ID_2:
				if (snake.key != VK_RIGHT && snake.key != VK_LEFT){
					snake.key = VK_LEFT;
				}
				break;
			case ID_3:
				snake.Flag = true;
				csnake.ShowPause();
				snake.ID_option = _max(ID_3);
				snake.Flag = false;
				csnake.ShowPause();
				break;
			case ID_4:
				snake.Flag = true;
				csnake.Die();
				snake.ID_option = _max(ID_2);
				snake.Flag = false;
				csnake.Die();
				break;
			}
			break;
			//�����Ҽ�
		case VK_RIGHT:
			switch (snake.ID_interface){
			case ID_2:
				if (snake.key != VK_LEFT && snake.key != VK_RIGHT){
					snake.key = VK_RIGHT;
				}
				break;
			case ID_3:
				snake.Flag = true;
				csnake.ShowPause();
				snake.ID_option = _min(ID_3);
				snake.Flag = false;
				csnake.ShowPause();
				break;
			case ID_4:
				snake.Flag = true;
				csnake.Die();
				snake.ID_option = _min(ID_2);
				snake.Flag = false;
				csnake.Die();
				break;
			}
			break;
			//���¿ո�ͻس���
		case VK_SPACE:
		case VK_RETURN:
			system("cls");
			switch (snake.ID_interface){
			case ID_1://���˵�����
				switch (snake.ID_option){
				case ID_1:
					snake.ID_interface = ID_2;//��ʼ��Ϸ����ID
					csnake.StartGame();
					break;
				case ID_2:
					snake.ID_interface = ID_5;//�ȼ�����
					snake.ID_option = ID_1;
					Frame();
					//csnake.ShowRank();
					break;
				case ID_3:
					snake.ID_interface = ID_6;//��ȡ��¼����
					snake.ID_option = ID_1;
					csnake.ShowRecord();
					break;
				case ID_4:
					snake.ID_interface = ID_7;//Ӣ�۰����
					csnake.ShowArmory();
					break;
				case ID_5:
					state = false;
					break;
				}
				break;

			case ID_2://��Ϸ����
				snake.ID_interface = ID_3;
				snake.ID_option = ID_1;
				Frame();
				//csnake.ShowPause();
				break;

			case ID_3://��ͣ����
				switch (snake.ID_option){
				case ID_1:
					snake.ID_interface = ID_2;
					csnake.StartGame();
					break;
				case ID_2:
					csnake.SaveRecord();
					break;
				case ID_3:
					state = false;
					break;
				}
				break;

			case ID_4://��������
				switch (snake.ID_option){
				case ID_1:
					snake.ID_interface = ID_1;
					snake.ID_option = ID_1;
					initialize_();
					csnake.ShowMenu();
					break;
				case ID_2:
					state = false;
					break;
				}
				break;

			case ID_5://�ȼ�����
				switch (snake.ID_option){
				case ID_1:
					snake.rank = first;
					break;
				case ID_2:
					snake.rank = middle;
					break;
				case ID_3:
					snake.rank = high;
					break;
				}
				snake.ID_interface = ID_1;
				snake.ID_option = ID_1;
				csnake.ShowMenu();
				break;

			case ID_6://��ȡ����
				size_t id;
				switch (snake.ID_option){
				case ID_1:
					id = 0; break;
				case ID_2:
					id = 1; break;
				case ID_3:
					id = 2; break;
				case ID_4:
					id = 3; break;
				case ID_5:
					id = 4; break;
				}
				//���ж�ȡ�ļ�
				if (snake.ID_option != ID_6&&snake.ID_option != ID_7){
					initialize_();
					if (csnake.Read(id)){
						snake.ID_interface = ID_2;
						csnake.StartGame();
					}
					else snake.ID_interface = ID_6;
				}
				else {
					snake.ID_interface = ID_1;
					snake.ID_option = ID_1;
					csnake.ShowMenu();
				}
				break;

			case ID_7://Ӣ�۰����
				snake.ID_interface = ID_1;
				snake.ID_option = ID_1;
				csnake.ShowMenu();
				break;
			}
			if (!state){
				COORD cd = { info.srWindow.Right / 4, info.srWindow.Bottom / 5 * 4 };
				SetConsoleCursorPosition(handle, cd);
				exit(0);
			}
			snake.ID_option = ID_1;
			break;
		}
	}
	//��Ϣ�����¸�����
	return CallNextHookEx(NULL, message, wParam, lParam);
}

//��ǽ�����͵�����Ӧ����(�Ѳ������)
void Wall(){
	short i;
	COORD coord = { 0, 0 };  //����ṹ
	//��ǽ
	SetConsoleCursorPosition(handle, coord);
	for (i = 0; i <= info.srWindow.Right; ++i)
		std::cout << "#";

	coord.X = info.srWindow.Right;
	coord.Y = 1;
	for (i = 1; i<info.srWindow.Bottom; ++i){
		SetConsoleCursorPosition(handle, coord);
		std::cout << "#";
		++coord.Y;
	}

	coord.X = 0;
	coord.Y = info.srWindow.Bottom;
	for (i = 1; i <= info.srWindow.Right; ++i){
		SetConsoleCursorPosition(handle, coord);
		std::cout << "#";
		++coord.X;
	}

	coord.X = 0;
	coord.Y = 1;
	for (i = 1; i<info.srWindow.Bottom; ++i){
		SetConsoleCursorPosition(handle, coord);
		std::cout << "#";
		++coord.Y;
	}
	//�ж����ڽ�����ʾ��ؽ���Ĳ˵�ѡ�����
	int j = info.srWindow.Right / 4;
	switch (snake.ID_interface){
	case ID_1:
		csnake.ShowMenu();
		coord.X = j;
		coord.Y = info.srWindow.Bottom - 6;
		SetConsoleCursorPosition(handle, coord);
		std::cout << "o(-\"-)o  ̰  #^_^#  ��  ��_��  ��  \\(^o^)/";
		break;//��ʾ�˵�ѡ��

	case ID_2:
	case ID_3:
	case ID_4:
		//�������Ϣ��
		coord.X = 1;
		coord.Y = info.srWindow.Bottom - 5;
		SetConsoleCursorPosition(handle, coord);
		for (i = 1; i<info.srWindow.Right; std::cout << "#", ++i);
		for (coord.X = j; coord.X <= info.srWindow.Right - j; coord.X += j){
			coord.Y = info.srWindow.Bottom - 5;
			for (i = coord.Y; i<info.srWindow.Bottom; ++i){
				SetConsoleCursorPosition(handle, coord);
				std::cout << "#";
				++coord.Y;
			}
		}
		//���ÿ�������Ϣ
		coord.X = 2;
		coord.Y -= 4;
		SetConsoleCursorPosition(handle, coord);
		std::cout << "��Ϸ�Ѷȣ�";
		coord.Y += 2;
		SetConsoleCursorPosition(handle, coord);
		std::cout << "\t   ";
		switch (snake.rank){
		case first:
			std::cout << "�� ��"; break;
		case middle:
			std::cout << "�� ��"; break;
		case high:
			std::cout << "�� ��"; break;
		}
		//��ǰ����
		coord.X += j;
		coord.Y -= 2;
		SetConsoleCursorPosition(handle, coord);
		std::cout << "  �� ǰ �� ��";
		coord.X += j / 2 - 3;
		coord.Y += 2;
		SetConsoleCursorPosition(handle, coord);
		std::cout << snake.mark;
		//����˵��
		coord.X = j * 2 + 1;
		coord.Y = info.srWindow.Bottom - 4;
		SetConsoleCursorPosition(handle, coord);
		std::cout << " ����˵��: ";
		coord.Y += 2;
		SetConsoleCursorPosition(handle, coord);
		std::cout << "  �� �� ��  ��";
		++coord.Y;
		SetConsoleCursorPosition(handle, coord);
		std::cout << " �ո� ��ͣ��Ϸ";
		//������
		coord.X += j;
		SetConsoleCursorPosition(handle, coord);
		std::cout << "\t�����ˣ� _ ��";
		break;

	case ID_5:
		csnake.ShowRank(); break;//��ʾ��Ϸ�ȼ�

	case ID_6:
		csnake.ShowRecord(); break;//��ʾ�浵��¼

	case ID_7:
		csnake.ShowArmory(); break;//��ʾӢ�۰�
	}

}

//������(���)
void Frame(){
	COORD coord = { 0, info.srWindow.Bottom / 3 };
	SetConsoleCursorPosition(handle, coord);
	for (short i = 0; i <= info.srWindow.Right; std::cout << "-", ++i);

	coord.Y = info.srWindow.Bottom / 3 * 2;
	SetConsoleCursorPosition(handle, coord);
	for (short i = 0; i <= info.srWindow.Right; std::cout << "-", ++i);

	switch (snake.ID_interface){
	case ID_3:
		csnake.ShowPause(); break;//��ʾ��ͣ�˵�
	case ID_4:
		csnake.Die(); break;//��ʾ��������˵�
	case ID_5:
		csnake.ShowRank(); break;//��ʾ�ȼ�ѡ��
	}
}

//��ʼ�������ݣ���ɣ�
void initialize_(){
	snake.state = true; //��״̬
	snake.Snake_size = 5; //�߳�ʼ������
	//��ʼ����λ��
	COORD cd;
	cd.Y = 3;
	snake.Snake_coord.clear();
	for (size_t i = 10; i>5; --i){
		cd.X = i;
		snake.Snake_coord.push_back(cd);
	}
	snake.food_coord.X = 0;
	snake.food_coord.Y = 0;
	snake.rank = first;   //Ĭ�ϵȼ�
	snake.mark = 0; //����
	snake.key = VK_RIGHT;
	snake.ID_interface = ID_1;//������
	snake.ID_option = ID_1;   //ѡ����
	snake.Flag = false;
}