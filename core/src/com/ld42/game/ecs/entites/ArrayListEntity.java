package com.ld42.game.ecs.entites;

import com.ld42.game.ecs.core.Component;
import com.ld42.game.ecs.core.Engine;
import com.ld42.game.ecs.core.Entity;

import java.util.*;

public class ArrayListEntity extends Entity{

    List<Component> components;

    public ArrayListEntity(Engine engine, String name) {
        super(engine, name);
        components = new ArrayList<>();
    }


    @Override
    public boolean add(Component o) {
        return components.add(o);
    }

    @Override
    public Component get(int i) {
        return components.get(i);
    }

    @Override
    public boolean remove(Component o) {
        return components.remove(o);
    }

    @Override
    public boolean contains(Component o) {
        return components.contains(o);
    }

    @Override
    public int size() {
        return components.size();
    }
}
