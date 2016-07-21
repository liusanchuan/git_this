// ConsoleApplication2.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include<iostream>
#include<string>


using namespace std;

class NvJiaBin
{
public:
	NvJiaBin() :name("NULL"),age(0),height(0),earn(0),NeedWaelth(0),NeedAppearance(0){};
	NvJiaBin(string Name,int Age,int Height,int Earn,int _NeedWealth,int _NeedAppearance,int _appearence){
		name = Name;
		age = Age;
		height = Height;
		earn = Earn;
		NeedWaelth = _NeedWealth;
		NeedAppearance = _NeedAppearance;
		appearence = _appearence;
	}
	void SetBasicInf(string Name, int Age, int Height, int Earn, int _NeedWealth, int _NeedAppearance, int _appearence){
		name = Name;
		age = Age;
		height = Height;
		earn = Earn;
		NeedWaelth = _NeedWealth;
		NeedAppearance = _NeedAppearance;
		appearence = _appearence;
	}

	int GetPermition(int Bwealth,string Bname){
		if (Bwealth >= NeedWaelth){
			GetBasicInformation();
			myBoy[myBoyCount++] = Bname;
			return(1);
		}
		else{
			cout << "you are rejected,sorry"<<endl;
			return 0;
		}
	}
	void GetBasicInformation(){
		cout << "My name is:" << name << endl;
		cout << "My height is:" << height << endl;
		cout << "My earn money peer month is:" << earn << endl;
		cout << "I`m willing to know more about you" << endl;
		
	}
	int getGirlAppearance(string IFBoy){
		for (int j = 0; j < myBoyCount; j++){
			if (IFBoy == myBoy[j]){
				cout << myBoy[j]<<"    __Is you";
				return appearence;
			}
		}
	}
private:
	string name;
	int age;
	int height;
	int earn;
	int appearence;

	int NeedWaelth;
	int NeedAppearance;
	string myBoy[10];
	int myBoyCount=0;
};


class NanJiaBin{
public:
	NanJiaBin(){
		name = "NULL";
		height = 0;
		wealth = 0;
		HeartGirlHeight = 0;
		HeartGirlAppearence = 0;
	}
	NanJiaBin(string Set_name, int Set_height, int Set_wealth, int Set_HeartgirlHeight, int SetHeartGielAppearence){
		name = Set_name;
		height = Set_wealth;
		wealth = Set_wealth;
		HeartGirlHeight = Set_HeartgirlHeight;
		HeartGirlAppearence = SetHeartGielAppearence;
	}
	string name;
	int height;
	int wealth;

	int Willing(int GirlAppearence){
		if (GirlAppearence > HeartGirlAppearence){
			cout << "we get married" << endl;
			cout << ".............................." << endl;
			return 1;
		}
	}


private:
	int HeartGirlHeight=0;
	int HeartGirlAppearence=0;
};

class Match{
public:
	int Match_2(NvJiaBin &MGirl, NanJiaBin &MBoy){
		int Get=0;
		int a= (MGirl.GetPermition(MBoy.wealth,MBoy.name));
		if (a == 1){
			int girlAppearance = MGirl.getGirlAppearance(MBoy.name);
			Get=MBoy.Willing(girlAppearance);
		}
		else{
			cout << "满园春色遮不住，何必纠结这一棵" << endl << "相信别人会记住你的" << endl;
		}
		cout << "match finish." << endl;
		return Get;
	}
};

class Window{
public:

	void BasicInformation(NanJiaBin &temp){
		cout<< "想找女朋友吗" << endl << "输入：" << endl << "1:想找，难耐如雪寂寞" << endl << "2：不想找，愿意孤独终老" << endl;
		int a;
		cin >> a;
		static int i = 0;
		if (a == 1){
			NanJiaBin nan[5];
			
			cout << endl << "请输入你的姓名：";
			cin >> nan[i].name;
			cout <<nan[i].name<<endl<<"输入你的月工资：";
			cin >> nan[1].wealth;
			cout << nan[1].wealth << endl << "输入你的身高";
			cin >> nan[1].height;
			cout << endl;
			i++;
		}
		else{
			cout << "%%D%%D%%D%%D%%D%%D";

		}
		
	}
	
};



int _tmain(int argc, _TCHAR* argv[])
{
	char*g = "fenghauxueyeupingfanshibaitairenshenghuo";
	string gi[24];
	NvJiaBin girl24[24];
	for (int i = 0; i < 24; i++){
		gi[i] = g[i];
		girl24[i].SetBasicInf(gi[i], 10 + i, 100 + i * 5, 5000 + 1000 * i, 5000 + 1000 * i, 60 + 5 * i, 60 + 5 * i);
		girl24[i].GetBasicInformation();
		cout << i << endl;
	}

	NanJiaBin tempNanjb;
	NanJiaBin &tempNan=tempNanjb;

	Window winD;
	Window &win=winD;
	//win = new Window;
	win.BasicInformation(tempNan);

	//cout << "tempNan:"<<tempNan->name << tempNan->height << tempNan->wealth << "...............";
	//NanJiaBin Boy2 = *tempNan;
	Match match1(girl24[1], tempNan);
	//system("cls");
	//NvJiaBin Girl1("XiaoXiao",12,165,10000,15000,180,80);
	//NvJiaBin Girl2("HuaHua", 18, 156, 6000, 10000, 175,90);

	//NanJiaBin Boy1("zhang",178,11000,150,85);
	//Match match(Girl1, Boy1);
	char a;
	cin>>a;
	return 0;
}