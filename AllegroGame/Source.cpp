#include "Header.h"

// ����� ������������ �������
const float FPS = 60;

// ������� ����
const int SCREEN_W = 640;
const int SCREEN_H = 480;

// ������� ��������
const int BOUNCER_SIZE = 32;

enum class MYKEYS
{
	KEY_UP, KEY_DOWN, KEY_LEFT, KEY_RIGHT
};


void main()
{
	// ������� (����)
	ALLEGRO_DISPLAY *display = nullptr;
	// ������� �������
	ALLEGRO_EVENT_QUEUE *event_queue = nullptr;
	// ������
	ALLEGRO_TIMER *timer = nullptr;
	// �������������� �� �����
	bool redraw = true;

	// ����� ������� ������
	bool key[4] = { false, false, false, false };
	bool doexit = false;

	// �����������
	ALLEGRO_BITMAP *bouncer = nullptr;
	// ��������� ���������� ��������� �����������
	float bouncer_x = SCREEN_W / 2.0 - BOUNCER_SIZE / 2.0;
	float bouncer_y = SCREEN_H / 2.0 - BOUNCER_SIZE / 2.0;
	// ���������� �������� ����������� (�� ������� �������� ����� ���������� �� x � y ����������)
	float bouncer_dx = -4.0, bouncer_dy = 4.0;
	
	// ��������
	ALLEGRO_BITMAP  *image = nullptr;


	// �������������� ����������
	if (!al_init())
	{
		cout << "failed to initialize allegro!\n";
		return;
	}

	// �������������� ����
	if (!al_install_mouse()) 
	{
		cout << "failed to initialize the mouse!\n";
		return;
	}

	// �������������� ����������
	if (!al_install_keyboard()) 
	{
		cout << "failed to initialize the keyboard!\n";
		return;
	}

	// ������� ������ � �������� ������������ 60 ��� � �������
	timer = al_create_timer(1.0 / FPS);

	if (!timer)
	{
		fprintf(stderr, "failed to create timer!\n");
		return;
	}

	// ������� �������
	display = al_create_display(640, 480);

	if (!display)
	{
		cout << "failed to create display!\n";
		return;
	}

	// ������������� ���� ���� � ������� �������
	al_clear_to_color(al_map_rgb(0, 0, 0));

	// ����������� �������
	al_flip_display();

	// �������� �� 10 ������
	//al_rest(10.0);

	// �������������� ����������� ������ (� ���������� ������� ����� �������� Image Addon)
	al_init_image_addon();

	// ��������� �����������: �����! �������� � ���������� ����� ������ ����� �������� �������
	image = al_load_bitmap("Panda.png");

	if (!image)
	{
		// ���� �� ������� ��������� - �������� � ������ (���������� ���������� Dialog Addon � ����������)
		al_show_native_message_box(display, "Error", "Error", "Failed to load image!", nullptr, ALLEGRO_MESSAGEBOX_ERROR);
		al_destroy_display(display);
		return;
	}

	// ������� �����������
	bouncer = al_create_bitmap(BOUNCER_SIZE, BOUNCER_SIZE);

	if (!bouncer) 
	{
		cout << "failed to create bouncer bitmap!\n";
		al_destroy_display(display);
		al_destroy_timer(timer);
		return;
	}

	// ������������� �������� ������ ������� �� �����������
	al_set_target_bitmap(bouncer);
	// ���������� ����������� � ������� ����
	al_clear_to_color(al_map_rgb(255, 0, 255));
	
	// ������������� �������� ������ ������� �� ������� (�� �������� �����������)
	al_set_target_bitmap(al_get_backbuffer(display));

	// ������� ������� �������
	event_queue = al_create_event_queue();

	if (!event_queue)
	{
		cout << "failed to create event_queue!\n";
		al_destroy_display(display);
		return;
	}

	// ������������ �������, ��� �������� ������� � ��������� ��� ������� �������
	al_register_event_source(event_queue, al_get_display_event_source(display));
	// ������������ ������, ��� �������� ������� � ��������� ��� ������� �������
	al_register_event_source(event_queue, al_get_timer_event_source(timer));

	// ������������ ����, ��� �������� �������
	al_register_event_source(event_queue, al_get_mouse_event_source());

	// ������������ ����������, ��� �������� �������
	al_register_event_source(event_queue, al_get_keyboard_event_source());

	// ��������� ������
	al_start_timer(timer);

	while (true)
	{
		////---------------------
		//// ������� � ����-�����:
		//ALLEGRO_EVENT ev; // ������ �������		
		//ALLEGRO_TIMEOUT timeout; // ������ �������� (������������, ��� ����-��� ��������� �������)
		//
		//// ������������� �������� �� 60 ���������� (�.�. � ������� ����� ������� �������� �������� �������)
		//al_init_timeout(&timeout, 0.06);

		//// �������� �������� �������
		//bool get_event = al_wait_for_event_until(event_queue, &ev, &timeout);

		//// ���� ������� �������� � ��� ������� �������� ���� - ��������� ���� �������
		//if (get_event && ev.type == ALLEGRO_EVENT_DISPLAY_CLOSE)
		//{
		//	cout << "Close the game\n";
		//	break;
		//}

		//// ��������� ������� (�������� � ������ ����)
		//al_clear_to_color(al_map_rgb(0, 0, 0));

		//// ����������� �������
		//al_flip_display();


		//---------------------
		// ������� � ��������:
		ALLEGRO_EVENT ev;
		// ���� �������
		al_wait_for_event(event_queue, &ev);

		// ���� ������ ������� �������, ������������� ���� ���������� �������
		if (ev.type == ALLEGRO_EVENT_TIMER) 
		{
			//// �������������� �����������
			//// ���� �������� ������ ������ �� ����������� ����������� �����������
			//if (bouncer_x < 0 || bouncer_x > SCREEN_W - BOUNCER_SIZE) 
			//{
			//	bouncer_dx = -bouncer_dx;
			//}
			//// ���� �������� ������ ������ �� ��������� ����������� �����������
			//if (bouncer_y < 0 || bouncer_y > SCREEN_H - BOUNCER_SIZE)
			//{
			//	bouncer_dy = -bouncer_dy;
			//}
			//// ��������� �����������
			//bouncer_x += bouncer_dx;
			//bouncer_y += bouncer_dy;

			if (key[(int)MYKEYS::KEY_UP] && bouncer_y >= 4.0)
			{
				bouncer_y -= 4.0;
			}

			if (key[(int)MYKEYS::KEY_DOWN] && bouncer_y <= SCREEN_H - BOUNCER_SIZE - 4.0)
			{
				bouncer_y += 4.0;
			}

			if (key[(int)MYKEYS::KEY_LEFT] && bouncer_x >= 4.0)
			{
				bouncer_x -= 4.0;
			}

			if (key[(int)MYKEYS::KEY_RIGHT] && bouncer_x <= SCREEN_W - BOUNCER_SIZE - 4.0)
			{
				bouncer_x += 4.0;
			}			

			redraw = true;
		}
		else if (ev.type == ALLEGRO_EVENT_DISPLAY_CLOSE)
		{
			break; // ����� �� ����
		}
		else if (ev.type == ALLEGRO_EVENT_MOUSE_AXES || ev.type == ALLEGRO_EVENT_MOUSE_ENTER_DISPLAY)
		{
			// ���� ���� ������� ���� - ���������� ����������� � �������
			bouncer_x = ev.mouse.x;
			bouncer_y = ev.mouse.y;
		}
		else if (ev.type == ALLEGRO_EVENT_KEY_DOWN)
		{
			switch (ev.keyboard.keycode)
			{
			case ALLEGRO_KEY_UP:
				key[(int)MYKEYS::KEY_UP] = true;
				break;

			case ALLEGRO_KEY_DOWN:
				key[(int)MYKEYS::KEY_DOWN] = true;
				break;

			case ALLEGRO_KEY_LEFT:
				key[(int)MYKEYS::KEY_LEFT] = true;
				break;

			case ALLEGRO_KEY_RIGHT:
				key[(int)MYKEYS::KEY_RIGHT] = true;
				break;
			}
		}
		else if (ev.type == ALLEGRO_EVENT_KEY_UP)
		{
			switch (ev.keyboard.keycode)
			{
			case ALLEGRO_KEY_UP:
				key[(int)MYKEYS::KEY_UP] = false;
				break;

			case ALLEGRO_KEY_DOWN:
				key[(int)MYKEYS::KEY_DOWN] = false;
				break;

			case ALLEGRO_KEY_LEFT:
				key[(int)MYKEYS::KEY_LEFT] = false;
				break;

			case ALLEGRO_KEY_RIGHT:
				key[(int)MYKEYS::KEY_RIGHT] = false;
				break;

			case ALLEGRO_KEY_ESCAPE:
				doexit = true;
				break;
			}
		}

		// ���� ���������� ���� ����������� ������ � ������� ������� �����, ������������� �������
		if (redraw && al_is_event_queue_empty(event_queue)) 
		{
			redraw = false;

			// ������� �����
			al_clear_to_color(al_map_rgb(0, 0, 0));

			// ������� �����������
			al_draw_bitmap(bouncer, bouncer_x, bouncer_y, 0);

			// ������� ��������
			al_draw_bitmap(image, 200, 200, 0);

			// ����������� �������
			al_flip_display();
		}
	}

	// ������� �����������
	al_destroy_bitmap(bouncer);

	// ������� ������
	al_destroy_timer(timer);

	// �������� �������
	al_destroy_display(display);

	// ������� ������� �������
	al_destroy_event_queue(event_queue);
}