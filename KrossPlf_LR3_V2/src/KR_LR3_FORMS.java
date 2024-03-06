import jdk.dynalink.linker.ConversionComparator;

import javax.swing.*;
import javax.swing.text.JTextComponent;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class KR_LR3_FORMS extends JFrame {
    private JButton задание23Button;
    private JPanel MainPanel;
    private JTextField textField1;
    private JTextPane textPane1;
    static JFrame forms;
    public KR_LR3_FORMS() {
        задание23Button.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                int Size;
                int value;
                Size = Integer.parseInt(textField1.getText());
                int[] arr=new int[Size];
                for(int i=0;i<textPane1.getComponentCount();i++){
                    arr[i]= Integer.parseInt(textPane1.getText());
                }


            }
        });

    }
    public static void main(String[] args) {
        KR_LR3_FORMS krLr3Forms = new KR_LR3_FORMS();
        krLr3Forms.setContentPane(krLr3Forms.MainPanel);
        krLr3Forms.setTitle("Главное меню");//Заголовок окна
        krLr3Forms.setSize(500,400);//Размер окна
        krLr3Forms.setVisible(true);//Отображение формы
        krLr3Forms.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);//Завершение работы программы после закрытия окна

    }
}
