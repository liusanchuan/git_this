#ifndef SNAKE
#define SNAKE

#include<windows.h>
#include<vector>
#include<string>

//��ǽ���Ͳ˵����ID
enum ID_ { ID_1 = 1, ID_2, ID_3, ID_4, ID_5, ID_6, ID_7 };

//��ǳ������м����߼�������Ϸ�ȼ�
enum Rank_ { first = 150, middle = 100, high = 50 };


//̰���߽ṹ   http://www.cnblogs.com/sosoft/
struct Snake_data{
	bool state;                    //�����״̬
	UINT Snake_size;                //����߳���
	std::vector<COORD> Snake_coord; //�ߵĵ�ǰ����
	COORD food_coord;               //ʳ������
	UINT rank;                     //��ǵȼ�
	UINT mark;                      //����
	UINT key;                       //��¼��������
	ID_ ID_interface;               //��ǵ�ǰͣ������ID
	short ID_option;               //��Ǳ�ѡ�в˵���ID
	bool Flag;                      //���ˢ��
};

//̰������
class Snake_class{
public:
	Snake_class(){}
	Snake_class(Snake_data *data) : pSnake(data){}
	void ShowMenu();            //��ʾ�˵�
	void StartGame();          //��ʼ��Ϸ
	void ShowPause();           //��ʾ��ͣ����
	void SaveRecord();          //�����¼
	void ShowRank();            //��ʾ�ȼ�
	void ShowRecord();          //��ʾ�浵��¼�б�
	bool Read(size_t);        //��ȡ��¼
	void ShowArmory();          //��ʾӢ�۰�
	void Die();                 //��������
	size_t Create_file();       //�洢�ļ�
private:
	void JudgeDie();            //�ж�����
	bool Jesus();               //�ϰ��ж�
	void ShowSnake(COORD&);   //��ʾ��
	void ShowPointer(COORD, std::string); //��ʾָ��
	void Show_not();            //��ʾ������
	Snake_data *pSnake;
};



#endif;