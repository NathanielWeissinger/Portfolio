import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.*;
import java.util.*;
import java.lang.*;

public class UI extends javax.swing.JFrame implements ActionListener, MouseListener {

    /**
     * Creates new form UI
     */
    public UI() {
        initComponents();
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">                          
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        jScrollPane2 = new javax.swing.JScrollPane();
        listModel = new DefaultListModel();
        jList2 = new javax.swing.JList(listModel);
        jLabel1 = new javax.swing.JLabel();
        jTextField1 = new javax.swing.JTextField();
        jLabel2 = new javax.swing.JLabel();
        jTextField2 = new javax.swing.JTextField();
        jLabel3 = new javax.swing.JLabel();
        jTextField3 = new javax.swing.JTextField();
        jLabel4 = new javax.swing.JLabel();
        jLabel5 = new javax.swing.JLabel();
        jTextField4 = new javax.swing.JTextField();
        jLabel6 = new javax.swing.JLabel();
        jCheckBox5 = new javax.swing.JCheckBox();
        jCheckBox6 = new javax.swing.JCheckBox();
        jScrollPane1 = new javax.swing.JScrollPane();
        jTextArea1 = new javax.swing.JTextArea();
        jLabel7 = new javax.swing.JLabel();
        jButton1 = new javax.swing.JButton();
        jButton2 = new javax.swing.JButton();
        jRadioButton1 = new javax.swing.JRadioButton();
        jRadioButton2 = new javax.swing.JRadioButton();
        jRadioButton3 = new javax.swing.JRadioButton();
        jRadioButton4 = new javax.swing.JRadioButton();
        group = new ButtonGroup();
        jButton3 = new javax.swing.JButton();
        jButton4 = new javax.swing.JButton();
        jScrollBar1 = new javax.swing.JScrollBar();
        jScrollBar2 = new javax.swing.JScrollBar();
        jCheckBox1 = new javax.swing.JCheckBox();
        items = new ArrayList();
        
        qItem = false;
        eItem = false;
        mItem = false;
        plat = false;
        gold = false;
        silv = false;

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("D&D Backpack Manager");
        setResizable(false);

        jScrollPane2.setViewportView(jList2);

        jLabel1.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jLabel1.setText("Item Value");

        jTextField1.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N

        jLabel2.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jLabel2.setText("Item Name");

        jTextField2.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        jTextField2.setHorizontalAlignment(javax.swing.JTextField.RIGHT);
        jTextField2.setText("0");

        jLabel3.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jLabel3.setText("Item Weight");

        jTextField3.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jTextField3.setHorizontalAlignment(javax.swing.JTextField.LEFT);
        jTextField3.setText("0");

        jLabel4.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jLabel4.setText("Lbs.");

        jLabel5.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jLabel5.setText("Quantity");

        jTextField4.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jTextField4.setHorizontalAlignment(javax.swing.JTextField.RIGHT);
        jTextField4.setText("0");
        jTextField4.setToolTipText("");

        jLabel6.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jLabel6.setText("Item Properties");

        jCheckBox5.setText("Equipable");

        jCheckBox6.setText("Magical");

        jTextArea1.setColumns(20);
        jTextArea1.setRows(5);
        jScrollPane1.setViewportView(jTextArea1);

        jLabel7.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jLabel7.setText("Special Notes");

        jButton1.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jButton1.setText("Save");

        jButton2.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jButton2.setText("Delete");

        jRadioButton1.setText("Copper");

        jRadioButton2.setText("Gold");

        jRadioButton3.setText("Silver");

        jRadioButton4.setText("Platinum");
        
        group.add(jRadioButton1);
        group.add(jRadioButton2);
        group.add(jRadioButton3);
        group.add(jRadioButton4);
        
        jRadioButton1.addActionListener(this);
        jRadioButton2.addActionListener(this);
        jRadioButton3.addActionListener(this);
        jRadioButton4.addActionListener(this);
        jButton1.addActionListener(this);
        jButton2.addActionListener(this);
        jButton3.addActionListener(this);
        jButton4.addActionListener(this);
        jCheckBox1.addActionListener(this);
        jCheckBox5.addActionListener(this);
        jCheckBox6.addActionListener(this);
        jTextField1.addActionListener(this);
        jTextField2.addActionListener(this);
        jTextField3.addActionListener(this);
        jTextField4.addActionListener(this);
        jList2.addMouseListener(this);

        jButton3.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jButton3.setText("Add");
        
        jButton4.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jButton4.setText("Load");

        jScrollBar2.setMaximum(25);

        jCheckBox1.setText("Quest Item");

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 148, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollBar1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(jLabel2, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                .addGap(76, 76, 76))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(jLabel3)
                                    .addComponent(jTextField1, javax.swing.GroupLayout.PREFERRED_SIZE, 183, javax.swing.GroupLayout.PREFERRED_SIZE))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)))
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(jLabel1)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                .addComponent(jTextField2, javax.swing.GroupLayout.PREFERRED_SIZE, 98, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addGap(61, 61, 61)
                                        .addComponent(jRadioButton3))
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addGap(60, 60, 60)
                                        .addComponent(jRadioButton1)))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(jRadioButton2)
                                    .addComponent(jRadioButton4))))
                        .addGap(1, 1, 1))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel5)
                            .addComponent(jTextField3, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.PREFERRED_SIZE, 67, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(97, 97, 97)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(jLabel6)
                                .addGap(0, 0, Short.MAX_VALUE))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(jCheckBox5)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(jCheckBox6)
                                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 315, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(jScrollBar2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(jButton2, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                    .addComponent(jButton3, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                    .addComponent(jButton4, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                    .addComponent(jButton1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addComponent(jTextField4)
                                        .addGap(81, 81, 81))
                                    .addGroup(jPanel1Layout.createSequentialGroup()
                                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                                            .addComponent(jLabel4)
                                            .addComponent(jLabel7))
                                        .addGap(59, 59, 59)))
                                .addComponent(jCheckBox1)
                                .addGap(0, 0, Short.MAX_VALUE)))
                        .addContainerGap())))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jScrollPane2)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGap(18, 18, 18)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel1)
                    .addComponent(jLabel2)
                    .addComponent(jTextField2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                        .addComponent(jRadioButton1)
                        .addComponent(jRadioButton2))
                    .addComponent(jTextField1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(4, 4, 4)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel3)
                    .addComponent(jRadioButton3)
                    .addComponent(jRadioButton4))
                .addGap(2, 2, 2)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jTextField3, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel4)
                    .addComponent(jLabel6))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                        .addComponent(jCheckBox5)
                        .addComponent(jCheckBox6))
                    .addComponent(jLabel5))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jTextField4, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jCheckBox1))
                .addGap(6, 6, 6)
                .addComponent(jLabel7)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanel1Layout.createSequentialGroup()
                        .addGap(0, 62, Short.MAX_VALUE)
                        .addComponent(jButton4)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jButton1)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jButton3)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jButton2))
                    .addComponent(jScrollBar2, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 132, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap())
            .addComponent(jScrollBar1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );

        pack();
    }// </editor-fold>
    
    public void mousePressed(MouseEvent e)
    {
        int index = jList2.getSelectedIndex();
        //set values
        jTextField1.setText(items.get(index).itemNameI);
        jTextField2.setText("" + items.get(index).itemValue);
        jTextField3.setText("" + items.get(index).itemWeight);
        jTextField4.setText("" + items.get(index).quantity);
        jCheckBox1.setSelected(items.get(index).qItemI);
        jCheckBox5.setSelected(items.get(index).eItemI);
        jCheckBox6.setSelected(items.get(index).mItemI);
        jRadioButton1.setSelected(items.get(index).coppI);
        jRadioButton2.setSelected(items.get(index).goldI);
        jRadioButton3.setSelected(items.get(index).silvI);
        jRadioButton4.setSelected(items.get(index).platI);
        jTextArea1.setText("" + items.get(index).notes);
    }
    public void mouseReleased(MouseEvent e)
    {
        
    }
    public void mouseExited(MouseEvent e)
    {
        
    }
    public void mouseEntered(MouseEvent e)
    {
        
    }
    public void mouseClicked(MouseEvent e)
    {
        
    }
    
    public void actionPerformed(ActionEvent e)
    {
        boolean toggle = false;
        
        if(e.getActionCommand().equals("Equipable") && !eItem && !toggle)
        {
            eItem = true;
            toggle = true;
        }
        if(e.getActionCommand().equals("Equipable") && eItem && !toggle)
        {
            eItem = false;
            toggle = true;
        }
        if(e.getActionCommand().equals("Magical") && !mItem && !toggle)
        {
            mItem = true;
            toggle = true;
        }
        if(e.getActionCommand().equals("Magical") && mItem && !toggle)
        {
            mItem = false;
            toggle = true;
        }
        if(e.getActionCommand().equals("Quest Item") && !qItem && !toggle)
        {
            qItem = true;
            toggle = true;
        }
        if(e.getActionCommand().equals("Quest Item") && qItem && !toggle)
        {
            qItem = false;
            toggle = true;
        }
        if(e.getActionCommand().equals("Copper") && !toggle)
        {
            copp = true;
            plat = false;
            gold = false;
            silv = false;
            toggle = true;
        }
        if(e.getActionCommand().equals("Gold") && !toggle)
        {
            copp = false;
            plat = false;
            gold = true;
            silv = false;
            toggle = true;
        }
        if(e.getActionCommand().equals("Platinum") && !toggle)
        {
            copp = false;
            plat = true;
            gold = false;
            silv = false;
            toggle = true;
        }
        if(e.getActionCommand().equals("Silver") && !toggle)
        {
            copp = false;
            plat = false;
            gold = false;
            silv = true;
            toggle = true;
        }
        if(e.getActionCommand().equals("Add") && !toggle)
        {
            Item i = new Item();
            i.isEquipable(eItem);
            i.isMagical(mItem);
            i.isQuestItem(qItem);
            if(copp)
            {
                i.isCopper(true);
                i.isSilver(false);
                i.isGold(false);
                i.isPlatinum(false);
            }
            if(silv)
            {
                i.isCopper(false);
                i.isSilver(true);
                i.isGold(false);
                i.isPlatinum(false);
            }
            if(gold)
            {
                i.isCopper(false);
                i.isSilver(false);
                i.isGold(true);
                i.isPlatinum(false);
            }
            if(plat)
            {
                i.isCopper(false);
                i.isSilver(false);
                i.isGold(false);
                i.isPlatinum(true);
            }
            i.itemNameI = jTextField1.getText();
            i.itemWeight = Double.parseDouble(jTextField2.getText());
            i.itemValue = Double.parseDouble(jTextField3.getText());
            i.quantity = Integer.parseInt(jTextField4.getText());
            i.notes = jTextArea1.getText();
            listModel.addElement(i.itemNameI);
            items.add(i);
            jList2.setSelectedIndex(items.size()-1);
            //add variables to GUI
        }
        if(e.getActionCommand().equals("Save") && !toggle)
        {
            PrintWriter log = null;
            try
            {
                File file = new File("itemsheet.txt");
                file.createNewFile();
                FileWriter logg =new FileWriter(file);
                log = new PrintWriter(logg);
                for(int i = 0; i<items.size(); i++)
                {
                    log.print(items.get(i).itemNameI+"$"+items.get(i).itemValue+
                        "$"+items.get(i).itemWeight+"$"+items.get(i).coppI+
                        "$"+items.get(i).goldI+"$"+items.get(i).silvI+
                        "$"+items.get(i).platI+"$"+items.get(i).quantity+
                        "$"+items.get(i).eItemI+"$"+items.get(i).mItemI+
                        "$"+items.get(i).qItemI+"$");
                        if(items.get(i).notes.equals("") || items.get(i).notes.equals(null))
                        {
                            items.get(i).notes = "No Notes";
                        }
                    log.print(items.get(i).notes + "$");
                    if(i<items.size()-1)
                        log.print("\n");
                }
                log.close();
                logg.close();
            } catch(Exception y){y.printStackTrace();}
            
            toggle = true;
        }
        if(e.getActionCommand().equals("Delete") && !toggle)
        {
            int index = jList2.getSelectedIndex();
            items.remove(index);
            listModel.remove(index);
            jList2.setSelectedIndex((index-1));
            //add variables to GUI
        }
        if(e.getActionCommand().equals("Load") && !toggle)
        {
            try
            {
                Scanner fileName=new Scanner(new File("itemsheet.txt"));
                while(fileName.hasNextLine())
                {
                    String x = fileName.nextLine();
                    StringTokenizer s = new StringTokenizer(x, "$");
                    
                    Item i = new Item();
                    i.itemNameI = s.nextToken();
                    i.itemValue = Double.parseDouble(s.nextToken());
                    i.itemWeight = Double.parseDouble(s.nextToken());
                    i.isCopper(Boolean.parseBoolean(s.nextToken()));
                    i.isGold(Boolean.parseBoolean(s.nextToken()));
                    i.isSilver(Boolean.parseBoolean(s.nextToken()));
                    i.isPlatinum(Boolean.parseBoolean(s.nextToken()));
                    i.quantity = Integer.parseInt(s.nextToken());
                    i.isEquipable(Boolean.parseBoolean(s.nextToken()));
                    i.isMagical(Boolean.parseBoolean(s.nextToken()));
                    i.isQuestItem(Boolean.parseBoolean(s.nextToken()));
                    i.notes = (String)s.nextToken();
                    
                    listModel.addElement(i.itemNameI);
                    items.add(i);                    
                }
                fileName.close();
            }catch(Exception f){f.printStackTrace();}
            
            //add variables to GUI
        }
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Metal".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(UI.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(UI.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(UI.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(UI.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new UI().setVisible(true);
            }
        });
    }
    
    public class Item
    {
        private boolean qItemI;
        private boolean eItemI;
        private boolean mItemI;
        private boolean platI;
        private boolean goldI;
        private boolean silvI;
        private boolean coppI;
        private String itemNameI;
        private double itemValue;
        private double itemWeight;
        private int quantity;
        String notes;
        
        void isEquipable(boolean tf)
        {
            eItemI = tf;
        }
        void isMagical(boolean tf)
        {
            mItemI = tf;
        }
        void isQuestItem(boolean tf)
        {
            qItemI = tf;
        }
        void isCopper(boolean tf)
        {
            qItemI = tf;
        }
        void isGold(boolean tf)
        {
            qItemI = tf;
        }
        void isSilver(boolean tf)
        {
            qItemI = tf;
        }
        void isPlatinum(boolean tf)
        {
            qItemI = tf;
        }
    }
    
    // Variables declaration - do not modify                     
    private javax.swing.JButton jButton1;//Save
    private javax.swing.JButton jButton2;//Delete
    private javax.swing.JButton jButton3;//Add
    private javax.swing.JButton jButton4;//Load
    private javax.swing.JCheckBox jCheckBox1;//Quest Item checkbox
    private javax.swing.JCheckBox jCheckBox5;//Equippable checkbox
    private javax.swing.JCheckBox jCheckBox6;//Magical checkbox
    private javax.swing.JLabel jLabel1;//
    private javax.swing.JLabel jLabel2;//
    private javax.swing.JLabel jLabel3;//
    private javax.swing.JLabel jLabel4;//
    private javax.swing.JLabel jLabel5;//
    private javax.swing.JLabel jLabel6;//
    private javax.swing.JLabel jLabel7;//
    private javax.swing.JList jList2;//
    private javax.swing.JPanel jPanel1;//
    private javax.swing.JRadioButton jRadioButton1;//Copper
    private javax.swing.JRadioButton jRadioButton2;//Gold
    private javax.swing.JRadioButton jRadioButton3;//Silver
    private javax.swing.JRadioButton jRadioButton4;//Platinum
    private javax.swing.ButtonGroup group;
    private javax.swing.JScrollBar jScrollBar1;//
    private javax.swing.JScrollBar jScrollBar2;//Text
    private javax.swing.JScrollPane jScrollPane1;//
    private javax.swing.JScrollPane jScrollPane2;//
    private javax.swing.JTextArea jTextArea1;//notes
    private javax.swing.JTextField jTextField1;//item name
    private javax.swing.JTextField jTextField2;//item value
    private javax.swing.JTextField jTextField3;//item weight
    private javax.swing.JTextField jTextField4;//quantity
    private DefaultListModel listModel;
    
    private boolean qItem;
    private boolean eItem;
    private boolean mItem;
    private boolean plat;
    private boolean gold;
    private boolean silv;
    private boolean copp;
    private ArrayList<Item> items;
    // End of variables declaration                   
}