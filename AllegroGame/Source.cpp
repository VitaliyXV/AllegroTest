#include "Header.h"

// время срабатывания таймера
const float FPS = 60;

// размеры окна
const int SCREEN_W = 640;
const int SCREEN_H = 480;

// размеры квадрата
const int BOUNCER_SIZE = 32;

enum class MYKEYS
{
	KEY_UP, KEY_DOWN, KEY_LEFT, KEY_RIGHT
};


void main()
{
	// дисплей (окно)
	ALLEGRO_DISPLAY *display = nullptr;
	// очередь событий
	ALLEGRO_EVENT_QUEUE *event_queue = nullptr;
	// таймер
	ALLEGRO_TIMER *timer = nullptr;
	// перерисовывать ли экран
	bool redraw = true;

	// флаги нажатия клавиш
	bool key[4] = { false, false, false, false };
	bool doexit = false;

	// изображение
	ALLEGRO_BITMAP *bouncer = nullptr;
	// вычисляем координаты появления изображения
	float bouncer_x = SCREEN_W / 2.0 - BOUNCER_SIZE / 2.0;
	float bouncer_y = SCREEN_H / 2.0 - BOUNCER_SIZE / 2.0;
	// определяем смещение изображения (на сколько пикселей будем перемещать по x и y координате)
	float bouncer_dx = -4.0, bouncer_dy = 4.0;
	
	// картинка
	ALLEGRO_BITMAP  *image = nullptr;


	// инициализируем библиотеку
	if (!al_init())
	{
		cout << "failed to initialize allegro!\n";
		return;
	}

	// инициализируем мышь
	if (!al_install_mouse()) 
	{
		cout << "failed to initialize the mouse!\n";
		return;
	}

	// инициализируем клавиатуру
	if (!al_install_keyboard()) 
	{
		cout << "failed to initialize the keyboard!\n";
		return;
	}

	// создаем таймер с частотой срабатывания 60 раз в секунду
	timer = al_create_timer(1.0 / FPS);

	if (!timer)
	{
		fprintf(stderr, "failed to create timer!\n");
		return;
	}

	// создаем дисплей
	display = al_create_display(640, 480);

	if (!display)
	{
		cout << "failed to create display!\n";
		return;
	}

	// устанавливаем цвет фона и очищаем дисплей
	al_clear_to_color(al_map_rgb(0, 0, 0));

	// переключаем дисплей
	al_flip_display();

	// задержка на 10 секунд
	//al_rest(10.0);

	// инициализируем графический модуль (в настройках проекта нужно включить Image Addon)
	al_init_image_addon();

	// загружаем изображение: ВАЖНО! работать с картинками можно только после создания дисплея
	image = al_load_bitmap("Panda.png");

	if (!image)
	{
		// если не удалось загрузить - сообщаем о ошибке (необходимо подключить Dialog Addon в настройках)
		al_show_native_message_box(display, "Error", "Error", "Failed to load image!", nullptr, ALLEGRO_MESSAGEBOX_ERROR);
		al_destroy_display(display);
		return;
	}

	// создаем изображение
	bouncer = al_create_bitmap(BOUNCER_SIZE, BOUNCER_SIZE);

	if (!bouncer) 
	{
		cout << "failed to create bouncer bitmap!\n";
		al_destroy_display(display);
		al_destroy_timer(timer);
		return;
	}

	// устанавливаем контекст вывода графики на изображение
	al_set_target_bitmap(bouncer);
	// окрашиваем изображение в розовый цвет
	al_clear_to_color(al_map_rgb(255, 0, 255));
	
	// устанавливаем контекст вывода графики на дисплей (на буферное изображение)
	al_set_target_bitmap(al_get_backbuffer(display));

	// создаем очередь событий
	event_queue = al_create_event_queue();

	if (!event_queue)
	{
		cout << "failed to create event_queue!\n";
		al_destroy_display(display);
		return;
	}

	// регистрируем дисплей, как источник событий и назначаем ему очередь событий
	al_register_event_source(event_queue, al_get_display_event_source(display));
	// регистрируем таймер, как источник событий и назначаем емы очередь событий
	al_register_event_source(event_queue, al_get_timer_event_source(timer));

	// регистрируем мышь, как источник событий
	al_register_event_source(event_queue, al_get_mouse_event_source());

	// регистрируем клавиатуру, как источник событий
	al_register_event_source(event_queue, al_get_keyboard_event_source());

	// запускаем таймер
	al_start_timer(timer);

	while (true)
	{
		////---------------------
		//// вариант с тайм-аутом:
		//ALLEGRO_EVENT ev; // объект события		
		//ALLEGRO_TIMEOUT timeout; // объект задержки (используется, как тайм-аут получения события)
		//
		//// устанавливаем задержку на 60 милисекунд (т.е. в течение этого времени пытаемся получить событие)
		//al_init_timeout(&timeout, 0.06);

		//// пытаемся получить событие
		//bool get_event = al_wait_for_event_until(event_queue, &ev, &timeout);

		//// если событие получено и это событие закрытия окна - прерываем цикл событий
		//if (get_event && ev.type == ALLEGRO_EVENT_DISPLAY_CLOSE)
		//{
		//	cout << "Close the game\n";
		//	break;
		//}

		//// обновляем дисплей (очисткой в черный цвет)
		//al_clear_to_color(al_map_rgb(0, 0, 0));

		//// переключаем дисплеи
		//al_flip_display();


		//---------------------
		// вариант с таймером:
		ALLEGRO_EVENT ev;
		// ждем события
		al_wait_for_event(event_queue, &ev);

		// если пришло событие таймера, устанавливаем флаг обновления дисплея
		if (ev.type == ALLEGRO_EVENT_TIMER) 
		{
			//// автоматическое перемещение
			//// если достигли границ экрана по горизонтали переключаем направление
			//if (bouncer_x < 0 || bouncer_x > SCREEN_W - BOUNCER_SIZE) 
			//{
			//	bouncer_dx = -bouncer_dx;
			//}
			//// если достигли границ экрана по вертикали переключаем направление
			//if (bouncer_y < 0 || bouncer_y > SCREEN_H - BOUNCER_SIZE)
			//{
			//	bouncer_dy = -bouncer_dy;
			//}
			//// выполняем перемещение
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
			break; // выход из игры
		}
		else if (ev.type == ALLEGRO_EVENT_MOUSE_AXES || ev.type == ALLEGRO_EVENT_MOUSE_ENTER_DISPLAY)
		{
			// если было событие мыши - перемещаем изображение к курсору
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

		// если установлен флаг перерисовки экрана и очередь событий пуста, переисовываем дисплей
		if (redraw && al_is_event_queue_empty(event_queue)) 
		{
			redraw = false;

			// очищаем экран
			al_clear_to_color(al_map_rgb(0, 0, 0));

			// выводим изображение
			al_draw_bitmap(bouncer, bouncer_x, bouncer_y, 0);

			// выводим картинку
			al_draw_bitmap(image, 200, 200, 0);

			// переключаем дисплей
			al_flip_display();
		}
	}

	// удаляем изображение
	al_destroy_bitmap(bouncer);

	// удаляем таймер
	al_destroy_timer(timer);

	// удаление дисплея
	al_destroy_display(display);

	// удаляем очередь событий
	al_destroy_event_queue(event_queue);
}