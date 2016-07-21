#include"Snake_Class.h"
#include<iostream>
#include<fstream>
#include<ctime>
#include<cstdlib>

//��ȡ���������
static const HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
static CONSOLE_SCREEN_BUFFER_INFO info;
//�����ߵļ�¼�����ļ�
static const char *Snake_Record[] = { "d://SnakeRecord//Snake1.txt",
"d://SnakeRecord//Snake2.txt",
"d://SnakeRecord//Snake3.txt",
"d://SnakeRecord//Snake4.txt",
"d://SnakeRecord//Snake5.txt" };

static const char *S_Armory[] = { "d://SnakeRecord//Armory1.txt",
"d://SnakeRecord//Armory2.txt",
"d://SnakeRecord//Armory3.txt" };
//��ʾ���˵�������Ѳ��ԣ�
void Snake_class::ShowMenu(){
	//��ȡ�����������Ϣ
	GetConsoleScreenBufferInfo(handle, &info);
	char *str[] = { "�� ʼ �� Ϸ",
		"�� �� �� ��",
		"�� ȡ �� ��",
		"Ӣ �� ��",
		"�� �� �� Ϸ" };
	//����˵�ѡ��
	short y = 3;
	COORD cd = { info.srWindow.Right / 2 - 5, y };
	for (size_t n = 0; n<sizeof(str) / sizeof(*str); ++n){
		SetConsoleCursorPosition(handle, cd);
		std::cout << *(str + n);
		cd.Y += 2;
	}
	//�ж�ָ��ָ���ĸ��˵�ѡ��
	cd.X -= 2;
	cd.Y = y;
	switch (pSnake->ID_option){
	case ID_1:
		break;
	case ID_2:
		cd.Y = y + 2; break;
	case ID_3:
		cd.Y = y + 4; break;
	case ID_4:
		cd.Y = y + 6; break;
	case ID_5:
		cd.Y = y + 8; break;
	}
	ShowPointer(cd, pSnake->Flag ? std::string("  ") : std::string("><"));
}

//��ʼ��Ϸ����ɴ����ԣ�
void Snake_class::StartGame(){
	COORD cd;
	//�ж��Ƿ�����ʳ��
	if (!pSnake->food_coord.X){
		srand((unsigned int)time(NULL));
		while (1){
			//����ʳ����ֵ����겻��Χǽ��ͬ
			++(cd.X = rand() % 78);
			++(cd.Y = rand() % 18);
			//�ж�ʳ�������Ƿ��������Ǻ�
			std::vector<COORD>::iterator ite;
			for (ite = pSnake->Snake_coord.begin(); ite != pSnake->Snake_coord.end(); ++ite){
				if (ite->X == cd.X && ite->Y == cd.Y)
					break;
			}
			if (ite == pSnake->Snake_coord.end()){
				pSnake->food_coord.X = cd.X;
				pSnake->food_coord.Y = cd.Y;
				break;
			}
		}
	}
	SetConsoleCursorPosition(handle, pSnake->food_coord);
	std::cout << "*";
	//�ж���������
	cd.X = pSnake->Snake_coord.begin()->X;
	cd.Y = pSnake->Snake_coord.begin()->Y;
	switch (pSnake->key){
	case VK_UP:
		--cd.Y; break;
	case VK_DOWN:
		++cd.Y; break;
	case VK_LEFT:
		--cd.X; break;
	case VK_RIGHT:
		++cd.X; break;
	}
	ShowSnake(cd);
	JudgeDie();
}

//��ʾ��ͣ����(����Ѳ���)
void Snake_class::ShowPause(){
	COORD cd = { info.srWindow.Right / 2 - 10, info.srWindow.Bottom / 5 };
	SetConsoleCursorPosition(handle, cd);
	std::cout << "�� Ϸ �� ͣ �� ......";
	char *str[] = { "�� �� �� Ϸ",
		"�� �� �� Ϸ",
		"�� �� �� Ϸ" };
	//����˵�ѡ��
	short X = info.srWindow.Right / 3;
	cd.X = X / 2 - 5;
	cd.Y = info.srWindow.Bottom / 3 * 2 - 4;
	for (size_t i = 0; i<sizeof(str) / sizeof(*str); ++i){
		SetConsoleCursorPosition(handle, cd);
		std::cout << *(str + i);
		cd.X += X;
	}

	//�ж�ָ��Ӧָ��Ĳ˵�ѡ��
	switch (pSnake->ID_option){
	case ID_1:
		cd.X = X / 2 - 7; break;
	case ID_2:
		cd.X = X / 2 + X - 7; break;
	case ID_3:
		cd.X = X / 2 + 2 * X - 7; break;
	}
	ShowPointer(cd, pSnake->Flag ? std::string("  ") : std::string("><"));
}

//�����¼�����δ���ԣ�
void Snake_class::SaveRecord(){
	std::ofstream outopen;
	outopen.open(*(Snake_Record + Create_file()));
	if (!outopen){
		std::cerr << "\n���ļ�ʧ�ܣ�\n";
		exit(0);
	}
	//�����¼���ļ���,ǰ���"0"��Ϊ�˺������Ƿ��ļ�Ϊ��ʹ��
	outopen << "0 " << pSnake->Snake_size << " ";
	for (std::vector<COORD>::iterator ite = pSnake->Snake_coord.begin();
		ite != pSnake->Snake_coord.end(); ++ite)
		outopen << ite->X << " " << ite->Y << " ";
	outopen << pSnake->rank << " " << pSnake->mark << " " << pSnake->key;
	outopen.close();
	//�������ɹ�
	COORD cd = { info.srWindow.Right / 2 - 4, info.srWindow.Bottom / 3 * 2 - 1 };
	SetConsoleCursorPosition(handle, cd);
	std::cout << "����ɹ�!\a";
}

//��ʾ�ȼ�(�Ѳ���)
void Snake_class::ShowRank(){
	COORD cd = { info.srWindow.Right / 2 - 6, info.srWindow.Bottom / 3 + 2 };
	char *str[] = { "��       ��",
		"��       ��",
		"��       ��" };
	for (size_t i = 0; i<sizeof(str) / sizeof(*str); ++i){
		SetConsoleCursorPosition(handle, cd);
		std::cout << *(str + i);
		cd.Y += 2;
	}
	//�ж�ָ����ͣ����ѡ��
	cd.X -= 2;
	cd.Y = info.srWindow.Bottom / 3 + 2;
	switch (pSnake->ID_option){
	case ID_1:
		break;
	case ID_2:
		cd.Y += 2; break;
	case ID_3:
		cd.Y += 4; break;
	}
	ShowPointer(cd, pSnake->Flag ? std::string("  ") : std::string("><"));
}

//��ʾ�浵��¼(�Ѳ���)
void Snake_class::ShowRecord(){
	COORD cd = { info.srWindow.Right / 2 - 12, 8 };
	//�����¼
	std::ifstream inopen;
	SetConsoleCursorPosition(handle, cd);
	for (size_t i = 0; i<sizeof(Snake_Record) / sizeof(*Snake_Record); ++i){
		inopen.open(*(Snake_Record + i));
		if (!inopen || (inopen.get() == EOF && i == 0)){
			Show_not();
			pSnake->ID_option = ID_7;//��7��ѡ����,�ڰ��س�ʱ�����
			return;
		}
		if (inopen.get() != EOF){
			UINT _rank, _mark;
			inopen >> _mark;
			++(_mark *= 2);
			while (_mark--)
				inopen >> _rank;
			inopen >> _mark;
			switch (_rank){
			case first:
				std::cout << "����"; break;
			case middle:
				std::cout << "�м�"; break;
			case high:
				std::cout << "�߼�"; break;
			}
			std::cout << "\t\t\t  " << _mark;
		}
		else
			std::cout << " ---\t\t\t  ---";

		cd.Y += 2;
		SetConsoleCursorPosition(handle, cd);
		inopen.close();
		inopen.clear();//������״̬
	}
	std::cout << "\t   �� �� �� ��";
	cd.X = info.srWindow.Right / 2 - 4;
	cd.Y = 4;
	SetConsoleCursorPosition(handle, cd);
	std::cout << "�� �� �� ¼";
	cd.X -= 10;
	cd.Y += 2;
	SetConsoleCursorPosition(handle, cd);
	std::cout << "��Ϸ�ȼ�\t\t��ǰ����";
	//���ָ��
	cd.X = info.srWindow.Right / 2 - 14;
	cd.Y = 8;
	switch (pSnake->ID_option){
	case ID_1:
		break;
	case ID_2:
		cd.Y += 2; break;
	case ID_3:
		cd.Y += 4; break;
	case ID_4:
		cd.Y += 6; break;
	case ID_5:
		cd.Y += 8; break;
	case ID_6:
		cd.Y += 10; break;
	}
	ShowPointer(cd, pSnake->Flag ? std::string("  ") : std::string("><"));
}

//��ȡ��¼
bool Snake_class::Read(size_t i){
	std::ifstream inopen(*(Snake_Record + i));
	if (inopen.get() == EOF){
		std::cout << "\a";
		inopen.close();
		return false;
	}
	inopen >> pSnake->Snake_size;
	COORD cd;
	pSnake->Snake_coord.clear();
	for (int n = 1; n <= pSnake->Snake_size; ++n){
		inopen >> cd.X >> cd.Y;
		pSnake->Snake_coord.push_back(cd);
	}
	inopen >> pSnake->rank >> pSnake->mark >> pSnake->key;
	inopen.close();
	inopen.clear();
	return true;
}

//��ʾӢ�۰�(δ����)
void Snake_class::ShowArmory(){
	short nt = 0;
	COORD cd = { info.srWindow.Right / 3, info.srWindow.Bottom / 3 };
	std::ifstream inopen;
	for (size_t i = 0; i<sizeof(S_Armory) / sizeof(*S_Armory); ++i){
		UINT _rank = 0, _mark = 0;
		inopen.open(*(S_Armory + i));
		if (!inopen){
			++nt;
			continue;
		}
		inopen >> _rank >> _mark;
		switch (_rank){
		case first:
			SetConsoleCursorPosition(handle, cd);
			std::cout << "Сţ ������\t\t  " << _mark;
			break;
		case middle:
			cd.Y += 2;
			SetConsoleCursorPosition(handle, cd);
			std::cout << "��ţ ���м�\t\t  " << _mark;
			break;
		case high:
			cd.Y += 2;
			SetConsoleCursorPosition(handle, cd);
			std::cout << "��ţ ���߼�\t\t  " << _mark;
			break;
		}
		inopen.close();
		inopen.clear();
	}
	if (nt == 3){
		Show_not();
		return;
	}
	cd.X = info.srWindow.Right / 2 - 3;
	cd.Y = 4;
	SetConsoleCursorPosition(handle, cd);
	std::cout << "Ӣ �� ��";
	cd.X -= 10;
	cd.Y += 2;
	SetConsoleCursorPosition(handle, cd);
	std::cout << "\t�� ��\t\t�� ��";
	cd.Y = info.srWindow.Bottom - 7;
	SetConsoleCursorPosition(handle, cd);
	std::cout << "���س��������˵�........";
}

//��������(δ����)
void Snake_class::Die(){
	COORD cd = { info.srWindow.Right / 2 - 10, info.srWindow.Bottom / 5 };
	SetConsoleCursorPosition(handle, cd);
	std::cout << "    �� �� x_x �� ��";
	char *str[] = { "�� �� �� ��",
		"�� �� �� Ϸ" };
	//����˵�ѡ��
	short X = info.srWindow.Right / 2;
	cd.X = X / 2 - 5;
	cd.Y = info.srWindow.Bottom / 3 * 2 - 4;
	for (size_t i = 0; i<sizeof(str) / sizeof(*str); ++i){
		SetConsoleCursorPosition(handle, cd);
		std::cout << *(str + i);
		cd.X += X;
	}

	//�ж�ָ��Ӧָ��Ĳ˵�ѡ��
	switch (pSnake->ID_option){
	case ID_1:
		cd.X = X / 2 - 7; break;
	case ID_2:
		cd.X = X / 2 + X - 7; break;
	}
	ShowPointer(cd, pSnake->Flag ? std::string("  ") : std::string("><"));
	if (Jesus()){
		cd.X = X / 2;
		cd.Y = info.srWindow.Bottom / 3;
		SetConsoleCursorPosition(handle, cd);
		std::cout << "Ӵ...��֣� �r(�s���t)�q Ҳ���ϰ񡣡�����";
		cd.Y += 2;
		SetConsoleCursorPosition(handle, cd);
		std::cout << "�ϰ�ȼ���";
		switch (pSnake->rank){
		case first:
			std::cout << "����"; break;
		case middle:
			std::cout << "�м�"; break;
		case high:
			std::cout << "�߼�"; break;
		}
		std::cout << "\t�ϰ������" << pSnake->mark;
	}
}

//�洢��¼�ļ�(���δ����)
size_t Snake_class::Create_file(){
	std::ifstream inopen;
	size_t fn = 0, fc = 0, iend = sizeof(Snake_Record) / sizeof(*Snake_Record);
	//�ж��ļ��Ƿ���ڻ��ļ��ѱ�����
	for (size_t i = 0; i<iend; ++i){
		inopen.open(*(Snake_Record + i));
		if (!inopen) ++fn;
		else if (inopen.get() == EOF){
			inopen.close();
			return i;
		}
		else { ++fc; inopen.close(); }
	}
	if (fn == iend || fc == iend){
		std::ofstream outopen;
		//�����ı�
		for (size_t i = 0; i<iend; ++i){
			outopen.open(*(Snake_Record + i));
			outopen.close();
		}
	}
	//���ش򿪳ɹ����ļ�����
	return 0;
}

//�ж�����(δ����)
void Snake_class::JudgeDie(){
	std::vector<COORD>::iterator hbeg = pSnake->Snake_coord.begin(),
		beg = hbeg + 1;
	while (beg != pSnake->Snake_coord.end()){
		if (beg->X == hbeg->X && beg->Y == hbeg->Y){
			pSnake->state = FALSE;
			return;
		}
		++beg;
	}
	COORD cd;
	if (hbeg->X <= 0 || hbeg->Y <= 0 ||
		hbeg->X >= info.srWindow.Right || hbeg->Y >= info.srWindow.Bottom - 5){
		if (pSnake->Snake_size < 40){
			pSnake->state = FALSE;
			return;
		}
		//����ﵽ��40�����Դ�ǽ
		switch (pSnake->key){
		case VK_UP:
			cd.X = pSnake->Snake_coord.begin()->X;
			cd.Y = info.srWindow.Bottom - 6;
			break;
		case VK_DOWN:
			cd.X = pSnake->Snake_coord.begin()->X;
			cd.Y = 1;
			break;
		case VK_LEFT:
			cd.X = info.srWindow.Right - 1;
			cd.Y = pSnake->Snake_coord.begin()->Y;
			break;
		case VK_RIGHT:
			cd.X = 1;
			cd.Y = pSnake->Snake_coord.begin()->Y;
			break;
		}
		ShowSnake(cd);
	}
}

//�ϰ��жϣ�δ���ԣ�
bool Snake_class::Jesus(){
	std::ifstream inopen;
	size_t i;
	//�ж���Ӧ�ȼ�����Ӧ�ļ�
	switch (pSnake->rank){
	case first:
		i = 0; break;
	case middle:
		i = 1; break;
	case high:
		i = 2; break;
	}
	inopen.open(*(S_Armory + i));
	if (inopen){
		UINT _mark;
		inopen >> _mark >> _mark;
		if (_mark >= pSnake->mark){
			inopen.close();
			return FALSE;
		}
	}
	std::ofstream outopen(*(S_Armory + i));//�����ļ�������
	if (!outopen){
		std::cerr << "��Ӣ�۰��ļ�����" << std::endl;
		exit(0);
	}
	outopen << pSnake->rank << " " << pSnake->mark;
	outopen.close();
	return TRUE;
}
//��ʾ��(δ����)
void Snake_class::ShowSnake(COORD& cd){
	if (cd.X == pSnake->food_coord.X && cd.Y == pSnake->food_coord.Y){
		//��������һ������
		pSnake->Snake_coord.push_back(*(pSnake->Snake_coord.rbegin()));
		pSnake->food_coord.X = pSnake->food_coord.Y = 0;//��־ʳ���ѱ��Ե�
		++pSnake->mark;
		++pSnake->Snake_size;
	}
	COORD cod;
	cod.X = (pSnake->Snake_coord.rbegin())->X;
	cod.Y = (pSnake->Snake_coord.rbegin())->Y;
	std::vector<COORD>::reverse_iterator rbeg = pSnake->Snake_coord.rbegin();
	while (rbeg != pSnake->Snake_coord.rend() - 1){
		rbeg->X = (rbeg + 1)->X;
		rbeg->Y = (rbeg + 1)->Y;
		++rbeg;
	}
	//��ʾ��
	pSnake->Snake_coord.begin()->X = cd.X;
	pSnake->Snake_coord.begin()->Y = cd.Y;
	for (std::vector<COORD>::iterator beg = pSnake->Snake_coord.begin();
		beg != pSnake->Snake_coord.end(); ++beg){
		SetConsoleCursorPosition(handle, *beg);
		std::cout << "*";
	}
	SetConsoleCursorPosition(handle, cod);
	std::cout << " ";
}

//��ʾָ�루��ɣ�
inline void Snake_class::ShowPointer(COORD cd, std::string str){
	SetConsoleCursorPosition(handle, cd);
	std::cout << str[0];
	pSnake->ID_interface != ID_6 ? cd.X += 14 : cd.X = info.srWindow.Right / 3 * 2 + 3;
	SetConsoleCursorPosition(handle, cd);
	std::cout << str[1];
}

//��ʾ������(���)
inline void Snake_class::Show_not(){
	COORD cd = { info.srWindow.Right / 2 - 4, info.srWindow.Bottom / 2 };
	SetConsoleCursorPosition(handle, cd);
	std::cout << "�� �� �� ��";
	cd.X -= 6;
	cd.Y += 2;
	SetConsoleCursorPosition(handle, cd);
	std::cout << "�밴�س��������˵�......";
}