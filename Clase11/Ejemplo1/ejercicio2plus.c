#include <sys/types.h>
#include <unistd.h>
#include <signal.h>
#include <stdio.h>
#include <time.h>

int continuar=1;

void capturar_senal(int iNumSen, siginfo_t *info, void *ni)
{
    printf("Se recibió la señal.\n");
    continuar=0;
}

void no_termino_nada(int iNumSen, siginfo_t *info, void *ni)
{
    
    printf("¡No termino nada!\n");
}

void tratarAlarma(int iNumSen, siginfo_t *info, void *ni)
{
    time_t rawtime;
    struct tm *timeinfo;

    //time(&rawtime);    
    //timeinfo = localtime(&rawtime);
    printf("(%d) - Hora Actual:  %s\n",  getpid(), "HOLA");//asctime(timeinfo));
    fflush(stdout);

    alarm(5);
    pause();
}

int main()
{
    time_t rawtime;
    struct tm *timeinfo;
    clock_t tiempo_inicio, tiempo_final;
    double segundos;
    tiempo_inicio = clock();
    struct sigaction act;              // La estructura que definirá como manejar la señal
    act.sa_sigaction = capturar_senal; // Definimos la rutina.
    sigfillset(&act.sa_mask);          // Bloqueamos todas las señales mientras se ejecuta la rutina.
    act.sa_flags = SA_SIGINFO;         // Es para que la estructura llegue instanciada a la rutina.
    sigaction(SIGUSR1, &act, NULL);     // Establecemos la captura de la señal.


    struct sigaction actsigint;              // La estructura que definirá como manejar la señal
    actsigint.sa_sigaction = no_termino_nada; // Definimos la rutina.
    sigfillset(&actsigint.sa_mask);          // Bloqueamos todas las señales mientras se ejecuta la rutina.
    actsigint.sa_flags = SA_SIGINFO;         // Es para que la estructura llegue instanciada a la rutina.
    sigaction(SIGINT, &actsigint, NULL);     // Establecemos la captura de la señal.
    

    struct sigaction actsigalarm;              // La estructura que definirá como manejar la señal
    actsigalarm.sa_sigaction = tratarAlarma;   // Definimos la rutina.
    sigfillset(&actsigalarm.sa_mask);          // Bloqueamos todas las señales mientras se ejecuta la rutina.
    actsigalarm.sa_flags = SA_SIGINFO;         // Es para que la estructura llegue instanciada a la rutina.
    sigaction(SIGALRM, &actsigalarm, NULL);     // Establecemos la captura de la señal.    


    alarm(5);
    pause();

    return 0;
}