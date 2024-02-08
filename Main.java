import java.util.Scanner;


public class Main {
    public static int fact1(int n){
        int res=1;
        for(int i=1;i<n;i+=2){
            res=res*i;
        }
        return res;
    }
    public static int fact2(int n){
        int res=1;
        for(int i=2;i<n;i+=2){
            res=res*i;
        }
        return res;
    }
    public static void function(int n,double x,double an,double e) {
        double sum=0;
        double sum_e=0;
        double sum_e10=0;
        System.out.println("n= "+0+" res= "+ an);
        for(int i=2;i<n+1;i+=2){
            sum+=an;
            if(Math.abs(an)>Math.abs(e)){
                sum_e+=an;
            }
            if(Math.abs(an)>Math.abs(e/10)){
                sum_e10+=an;
            }
            an=an*((i-1)*Math.pow(x,2))/i;
            System.out.println("n= "+i+" res= "+ an);

        }
        System.out.println("Сумма ряда: "+sum);
        System.out.println("Сумма элементов больших е: "+sum_e);
        System.out.println("Сумма элементов больших е/10: "+sum_e10);
    }
    public static void main(String[] args) {
        int v;
        while(true){
            Scanner in = new Scanner(System.in);
            System.out.println("1)Задание 5\n2)Задание 6\n0)Выход");
            v=in.nextInt();
            switch (v)
            {
                case 1:
                    Scanner in2 = new Scanner(System.in);
                    System.out.println("Укажите высоту треугольника: ");
                    int H = in2.nextInt();
                    int len=1;
                    if(H<3)
                    {
                        System.out.println("Высота треугольника не может быть меньше трёх");
                    }
                    else
                    {
                        System.out.println("*");
                        System.out.print("|");
                        System.out.print("\\"+"\n");
                        len=len+2;
                        for(int i =0;i<H-3;i++)
                        {
                            if(i<H-3)
                            {
                                System.out.print("|");
                                for(int j=0;j<len-2;j++){
                                    System.out.print(" ");
                                }
                                len++;
                                System.out.println("\\");
                            }
                        }
                        System.out.print("*");
                        for(int j=0;j<len-2;j++){
                            System.out.print("_");
                        }
                        System.out.print("*");
                    }
                    break;
                case 2:
                    int R=1000;
                    double x;
                    int n;
                    double e;
                    Scanner in3 = new Scanner(System.in);
                    Scanner in4 = new Scanner(System.in);
                    Scanner in5 = new Scanner(System.in);
                    System.out.println("Введите x в диапазоне от -1000 до 1000");
                    x=in4.nextDouble();
                    if(x<-1000||x>1000){
                        System.out.println("х не входит в указанный диапазон");
                    }
                    System.out.println("Введите число n");
                    n=in3.nextInt();
                    if(n<0){
                        System.out.println("n не может быть меньше нуля");
                    }
                    System.out.println("Введите е");
                    e=in5.nextDouble();
                    double a0=1;
                    function(n,x,a0,e);
                    break;

            }
            if(v==0) break;
        }


    }
}